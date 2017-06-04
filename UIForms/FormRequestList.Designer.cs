namespace UIForms
{
    partial class FormRequestList
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewRequisicoes = new System.Windows.Forms.ListView();
            this.btnRequisicao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewRequisicoes
            // 
            this.listViewRequisicoes.Location = new System.Drawing.Point(21, 63);
            this.listViewRequisicoes.Name = "listViewRequisicoes";
            this.listViewRequisicoes.Size = new System.Drawing.Size(734, 432);
            this.listViewRequisicoes.TabIndex = 5;
            this.listViewRequisicoes.UseCompatibleStateImageBehavior = false;
            this.listViewRequisicoes.DoubleClick += new System.EventHandler(this.listViewRequisicoes_DoubleClick);
            // 
            // btnRequisicao
            // 
            this.btnRequisicao.Location = new System.Drawing.Point(21, 12);
            this.btnRequisicao.Name = "btnRequisicao";
            this.btnRequisicao.Size = new System.Drawing.Size(216, 29);
            this.btnRequisicao.TabIndex = 3;
            this.btnRequisicao.Text = "Nova Requisição";
            this.btnRequisicao.UseVisualStyleBackColor = true;
            this.btnRequisicao.Click += new System.EventHandler(this.btnRequisicao_Click);
            // 
            // FormRequestList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 517);
            this.Controls.Add(this.listViewRequisicoes);
            this.Controls.Add(this.btnRequisicao);
            this.Name = "FormRequestList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Requisições";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewRequisicoes;
        private System.Windows.Forms.Button btnRequisicao;
    }
}