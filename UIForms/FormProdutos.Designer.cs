namespace UIForms
{
    partial class FormProdutos
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
            this.btnProdutoSimples = new System.Windows.Forms.Button();
            this.btnProdutoComposto = new System.Windows.Forms.Button();
            this.listViewProdutos = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnProdutoSimples
            // 
            this.btnProdutoSimples.Location = new System.Drawing.Point(32, 26);
            this.btnProdutoSimples.Name = "btnProdutoSimples";
            this.btnProdutoSimples.Size = new System.Drawing.Size(216, 29);
            this.btnProdutoSimples.TabIndex = 0;
            this.btnProdutoSimples.Text = "Novo produto simples";
            this.btnProdutoSimples.UseVisualStyleBackColor = true;
            this.btnProdutoSimples.Click += new System.EventHandler(this.BtnProdutoSimples_Click);
            // 
            // btnProdutoComposto
            // 
            this.btnProdutoComposto.Location = new System.Drawing.Point(268, 26);
            this.btnProdutoComposto.Name = "btnProdutoComposto";
            this.btnProdutoComposto.Size = new System.Drawing.Size(216, 29);
            this.btnProdutoComposto.TabIndex = 1;
            this.btnProdutoComposto.Text = "Novo produto composto";
            this.btnProdutoComposto.UseVisualStyleBackColor = true;
            this.btnProdutoComposto.Click += new System.EventHandler(this.BtnProdutoComposto_Click);
            // 
            // listViewProdutos
            // 
            this.listViewProdutos.Location = new System.Drawing.Point(32, 77);
            this.listViewProdutos.Name = "listViewProdutos";
            this.listViewProdutos.Size = new System.Drawing.Size(770, 445);
            this.listViewProdutos.TabIndex = 2;
            this.listViewProdutos.UseCompatibleStateImageBehavior = false;
            this.listViewProdutos.DoubleClick += new System.EventHandler(this.ListViewProdutos_DoubleClick);
            // 
            // FormProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 553);
            this.Controls.Add(this.listViewProdutos);
            this.Controls.Add(this.btnProdutoComposto);
            this.Controls.Add(this.btnProdutoSimples);
            this.Name = "FormProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produtos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProdutoSimples;
        private System.Windows.Forms.Button btnProdutoComposto;
        private System.Windows.Forms.ListView listViewProdutos;
    }
}