namespace UIForms
{
    partial class FormMain
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
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requisiçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requisiçõesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saídasDoEstoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produtosToolStripMenuItem,
            this.requisiçõesToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(869, 28);
            this.menuPrincipal.TabIndex = 3;
            this.menuPrincipal.Text = "Menu Principal";
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.produtosToolStripMenuItem.Text = "Produtos";
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.ProdutosToolStripMenuItem_Click);
            // 
            // requisiçõesToolStripMenuItem
            // 
            this.requisiçõesToolStripMenuItem.Name = "requisiçõesToolStripMenuItem";
            this.requisiçõesToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.requisiçõesToolStripMenuItem.Text = "Requisições";
            this.requisiçõesToolStripMenuItem.Click += new System.EventHandler(this.RequisiçõesToolStripMenuItem_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.requisiçõesToolStripMenuItem1,
            this.saídasDoEstoqueToolStripMenuItem});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // requisiçõesToolStripMenuItem1
            // 
            this.requisiçõesToolStripMenuItem1.Name = "requisiçõesToolStripMenuItem1";
            this.requisiçõesToolStripMenuItem1.Size = new System.Drawing.Size(206, 26);
            this.requisiçõesToolStripMenuItem1.Text = "Requisições";
            this.requisiçõesToolStripMenuItem1.Click += new System.EventHandler(this.RequisiçõesToolStripMenuItem1_Click);
            // 
            // saídasDoEstoqueToolStripMenuItem
            // 
            this.saídasDoEstoqueToolStripMenuItem.Name = "saídasDoEstoqueToolStripMenuItem";
            this.saídasDoEstoqueToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.saídasDoEstoqueToolStripMenuItem.Text = "Saídas do estoque";
            this.saídasDoEstoqueToolStripMenuItem.Click += new System.EventHandler(this.SaídasDoEstoqueToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 561);
            this.Controls.Add(this.menuPrincipal);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPrincipal";
            this.Text = "Projeto Triade";
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requisiçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requisiçõesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saídasDoEstoqueToolStripMenuItem;
    }
}