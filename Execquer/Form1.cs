using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Execquer
{
    public partial class MainForm : Form
    {
        private List<string> _sqlFiles = new List<string>();
        private List<ConnInfo> _availableConnections = new List<ConnInfo>();

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;

            // Botões
            btnAddFiles.Click += BtnAddFiles_Click;
            btnRemoveSelected.Click += BtnRemoveSelected_Click;
            btnMoveUp.Click += BtnMoveUp_Click;
            btnMoveDown.Click += BtnMoveDown_Click;
            btnExecute.Click += BtnExecute_Click;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _availableConnections = LoadConnectionsFromJson();

            cmbConnections.Items.Clear();
            cmbConnections.Items.AddRange(_availableConnections.Select(c => c.Name).ToArray());

            if (cmbConnections.Items.Count > 0)
                cmbConnections.SelectedIndex = 0;
        }

        private List<ConnInfo> LoadConnectionsFromJson()
        {
            string path = Path.Combine(Application.StartupPath, "Connections.json");

            if (!File.Exists(path))
                return new List<ConnInfo>();

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<ConnInfo>>(json);
        }

        private void BtnAddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "SQL Files (*.sql)|*.sql"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    if (!_sqlFiles.Contains(file))
                    {
                        _sqlFiles.Add(file);
                        lstFiles.Items.Add(Path.GetFileName(file));
                    }
                }

                UpdatePreview();
            }
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            int index = lstFiles.SelectedIndex;
            if (index >= 0 && index < _sqlFiles.Count)
            {
                _sqlFiles.RemoveAt(index);
                lstFiles.Items.RemoveAt(index);
                UpdatePreview();
            }
        }

        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            int index = lstFiles.SelectedIndex;
            if (index > 0)
            {
                Swap(index, index - 1);
                lstFiles.SelectedIndex = index - 1;
                UpdatePreview();
            }
        }

        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            int index = lstFiles.SelectedIndex;
            if (index >= 0 && index < _sqlFiles.Count - 1)
            {
                Swap(index, index + 1);
                lstFiles.SelectedIndex = index + 1;
                UpdatePreview();
            }
        }

        private void Swap(int i, int j)
        {
            (_sqlFiles[i], _sqlFiles[j]) = (_sqlFiles[j], _sqlFiles[i]);

            var tempItem = lstFiles.Items[i];

            lstFiles.Items[i] = lstFiles.Items[j];
            lstFiles.Items[j] = tempItem;
        }

        private void UpdatePreview()
        {
            txtPreview.Clear();

            foreach (var file in _sqlFiles)
            {
                txtPreview.AppendText($"-- {Path.GetFileName(file)}\r\n");
                txtPreview.AppendText(File.ReadAllText(file));
                txtPreview.AppendText("\r\nGO\r\n\r\n");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Abrir diálogo para escolher o diretório
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialog.SelectedPath;

                // Nome do arquivo (pode customizar se quiser perguntar para o usuário)
                string fileName = $"script_{DateTime.Now:yyyyMMdd_HHmmss}.sql";
                string fullPath = Path.Combine(selectedDirectory, fileName);

                try
                {
                    // Escrever o conteúdo do txtPreview no arquivo
                    File.WriteAllText(fullPath, txtPreview.Text);
                    MessageBox.Show($"Arquivo salvo com sucesso em:\n{fullPath}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar o arquivo:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void BtnExecute_Click(object sender, EventArgs e)
        {
            string connStr = GetSelectedConnectionString();

            if (string.IsNullOrEmpty(connStr))
            {
                MessageBox.Show("Selecione uma conexão válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPreview.Text))
            {
                MessageBox.Show("Nenhum script para executar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(txtPreview.Text, conn);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Script pronto para execução com a conexão:\n\n{connStr}", "Executar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar o script:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSelectedConnectionString()
        {
            string selectedName = cmbConnections.SelectedItem?.ToString();
            return _availableConnections.FirstOrDefault(c => c.Name == selectedName)?.ConnectionString;
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            // Só pra evitar erro se o evento for ativado por acidente
        }        
    }
}
