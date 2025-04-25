using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execquer
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class NomeArquivoForm : Form
    {
        public string NomeArquivo { get; private set; }

        private TextBox txtNomeArquivo;
        private Button btnOK;
        private Button btnCancel;

        public NomeArquivoForm()
        {
            // Configuração do formulário
            this.Icon = new Icon(Properties.Resources.exequer_icon, new Size(32, 32));
            this.Text = "Escolher Nome do Arquivo";
            this.Size = new System.Drawing.Size(300, 150);

            // Caixa de texto para nome do arquivo
            txtNomeArquivo = new TextBox();
            txtNomeArquivo.Size = new System.Drawing.Size(200, 20);
            txtNomeArquivo.Location = new System.Drawing.Point(50, 30);
            this.Controls.Add(txtNomeArquivo);

            // Botão OK
            btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Size = new System.Drawing.Size(75, 23);
            btnOK.Location = new System.Drawing.Point(50, 70);
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Click += (sender, e) => { NomeArquivo = txtNomeArquivo.Text; };
            this.Controls.Add(btnOK);

            // Botão Cancelar
            btnCancel = new Button();
            btnCancel.Text = "Cancelar";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.Location = new System.Drawing.Point(150, 70);
            btnCancel.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);
        }
    }
}
