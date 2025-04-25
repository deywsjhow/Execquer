using System.Windows.Forms;
using System;
using System.Drawing;

namespace Execquer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Label lblPreviewTitle;
        private System.Windows.Forms.Panel pnlPreviewWrapper;
        private System.Windows.Forms.TextBox txtPreview;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.ComboBox cmbConnections;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnSave; // Novo botão de salvar
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog; // Caixa de diálogo para salvar

        private void InitializeComponent()
        {
            // Update the line causing the error to use the correct constructor for the Icon property.
            this.Icon = Properties.Resources.exequer_icon; // Original line causing the error

            // Corrected line:
            this.Icon = new Icon(Properties.Resources.exequer_icon, new Size(32, 32));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.lblPreviewTitle = new System.Windows.Forms.Label();
            this.pnlPreviewWrapper = new System.Windows.Forms.Panel();
            this.txtPreview = new System.Windows.Forms.TextBox();
            this.lblConnection = new System.Windows.Forms.Label();
            this.cmbConnections = new System.Windows.Forms.ComboBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button(); // Inicializando o botão de salvar
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog(); // Inicializando o FolderBrowserDialog
            this.pnlPreviewWrapper.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(720, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Execquer - Executor de Scripts SQL";
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Location = new System.Drawing.Point(10, 50);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(150, 30);
            this.btnAddFiles.TabIndex = 1;
            this.btnAddFiles.Text = "Adicionar arquivos";
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Location = new System.Drawing.Point(170, 50);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(160, 30);
            this.btnRemoveSelected.TabIndex = 2;
            this.btnRemoveSelected.Text = "Remover selecionado";
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(340, 50);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(30, 30);
            this.btnMoveUp.TabIndex = 3;
            this.btnMoveUp.Text = "↑";
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(380, 50);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(30, 30);
            this.btnMoveDown.TabIndex = 4;
            this.btnMoveDown.Text = "↓";
            // 
            // lstFiles
            // 
            this.lstFiles.Location = new System.Drawing.Point(10, 90);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(710, 147);
            this.lstFiles.TabIndex = 5;
            // 
            // lblPreviewTitle
            // 
            this.lblPreviewTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPreviewTitle.Location = new System.Drawing.Point(10, 250);
            this.lblPreviewTitle.Name = "lblPreviewTitle";
            this.lblPreviewTitle.Size = new System.Drawing.Size(250, 20);
            this.lblPreviewTitle.TabIndex = 6;
            this.lblPreviewTitle.Text = "Pré-visualização do Script";
            // 
            // pnlPreviewWrapper
            // 
            this.pnlPreviewWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPreviewWrapper.Controls.Add(this.txtPreview);
            this.pnlPreviewWrapper.Location = new System.Drawing.Point(10, 275);
            this.pnlPreviewWrapper.Name = "pnlPreviewWrapper";
            this.pnlPreviewWrapper.Size = new System.Drawing.Size(710, 200);
            this.pnlPreviewWrapper.TabIndex = 7;
            // 
            // txtPreview
            // 
            this.txtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPreview.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtPreview.Location = new System.Drawing.Point(0, 0);
            this.txtPreview.Multiline = true;
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.ReadOnly = true;
            this.txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPreview.Size = new System.Drawing.Size(708, 198);
            this.txtPreview.TabIndex = 0;
            this.txtPreview.WordWrap = false;
            // 
            // lblConnection
            // 
            this.lblConnection.Location = new System.Drawing.Point(10, 485);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(50, 20);
            this.lblConnection.TabIndex = 8;
            this.lblConnection.Text = "Conexão: ";
            // 
            // cmbConnections
            // 
            this.cmbConnections.Location = new System.Drawing.Point(80, 482);
            this.cmbConnections.Name = "cmbConnections";
            this.cmbConnections.Size = new System.Drawing.Size(300, 21);
            this.cmbConnections.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 520);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 30);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Salvar Arquivo SQL"; // Novo texto para o botão de salvar
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click); // Adicionando o evento de clique
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(400, 480);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(150, 30);
            this.btnExecute.TabIndex = 11;
            this.btnExecute.Text = "Executar Script";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(740, 575); // Novo tamanho do formulário
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAddFiles);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.lblPreviewTitle);
            this.Controls.Add(this.pnlPreviewWrapper);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.cmbConnections);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnSave); // Adicionando o botão de salvar
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Execquer";
            this.pnlPreviewWrapper.ResumeLayout(false);
            this.pnlPreviewWrapper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
