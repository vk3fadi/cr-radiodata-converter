namespace TS2K
{
  partial class MainWindow
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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.load2k0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.loadCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pasteCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.parseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.copyMCPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.CSVTextBox = new System.Windows.Forms.TextBox();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.label1 = new System.Windows.Forms.Label();
      this.MCPTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pasteCSVToolStripMenuItem,
            this.parseToolStripMenuItem,
            this.copyMCPToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1058, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.load2k0ToolStripMenuItem,
            this.loadCSVToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
      this.newToolStripMenuItem.Text = "New";
      // 
      // load2k0ToolStripMenuItem
      // 
      this.load2k0ToolStripMenuItem.Name = "load2k0ToolStripMenuItem";
      this.load2k0ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
      this.load2k0ToolStripMenuItem.Text = "Load 2K0";
      // 
      // loadCSVToolStripMenuItem
      // 
      this.loadCSVToolStripMenuItem.Name = "loadCSVToolStripMenuItem";
      this.loadCSVToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
      this.loadCSVToolStripMenuItem.Text = "Load CSV/HMK";
      this.loadCSVToolStripMenuItem.Click += new System.EventHandler(this.loadCSVToolStripMenuItem_Click);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
      this.saveToolStripMenuItem.Text = "Save 2K0";
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      // 
      // pasteCSVToolStripMenuItem
      // 
      this.pasteCSVToolStripMenuItem.Name = "pasteCSVToolStripMenuItem";
      this.pasteCSVToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
      this.pasteCSVToolStripMenuItem.Text = "Paste CSV";
      this.pasteCSVToolStripMenuItem.Click += new System.EventHandler(this.pasteCSVToolStripMenuItem_Click);
      // 
      // parseToolStripMenuItem
      // 
      this.parseToolStripMenuItem.Name = "parseToolStripMenuItem";
      this.parseToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
      this.parseToolStripMenuItem.Text = "Convert";
      this.parseToolStripMenuItem.Click += new System.EventHandler(this.parseToolStripMenuItem_Click);
      // 
      // copyMCPToolStripMenuItem
      // 
      this.copyMCPToolStripMenuItem.Name = "copyMCPToolStripMenuItem";
      this.copyMCPToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
      this.copyMCPToolStripMenuItem.Text = "Copy MCP";
      this.copyMCPToolStripMenuItem.Click += new System.EventHandler(this.copyMCPToolStripMenuItem_Click);
      // 
      // CSVTextBox
      // 
      this.CSVTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CSVTextBox.Location = new System.Drawing.Point(0, 13);
      this.CSVTextBox.Multiline = true;
      this.CSVTextBox.Name = "CSVTextBox";
      this.CSVTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.CSVTextBox.Size = new System.Drawing.Size(526, 520);
      this.CSVTextBox.TabIndex = 1;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 24);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.CSVTextBox);
      this.splitContainer1.Panel1.Controls.Add(this.label1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.MCPTextBox);
      this.splitContainer1.Panel2.Controls.Add(this.label2);
      this.splitContainer1.Size = new System.Drawing.Size(1058, 533);
      this.splitContainer1.SplitterDistance = 526;
      this.splitContainer1.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Top;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(83, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "CSV/HMK Data";
      // 
      // MCPTextBox
      // 
      this.MCPTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MCPTextBox.Location = new System.Drawing.Point(0, 13);
      this.MCPTextBox.Multiline = true;
      this.MCPTextBox.Name = "MCPTextBox";
      this.MCPTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.MCPTextBox.Size = new System.Drawing.Size(528, 520);
      this.MCPTextBox.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Dock = System.Windows.Forms.DockStyle.Top;
      this.label2.Location = new System.Drawing.Point(0, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(56, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "MCP Data";
      // 
      // MainWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1058, 557);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainWindow";
      this.Text = "Form1";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem loadCSVToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem load2k0ToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pasteCSVToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copyMCPToolStripMenuItem;
    private System.Windows.Forms.TextBox CSVTextBox;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox MCPTextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ToolStripMenuItem parseToolStripMenuItem;
  }
}

