using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TS2K
{
  public partial class MainWindow : Form
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void loadHMKToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void loadCSVToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog d = new OpenFileDialog();
      d.Filter = "CSV/HMK|*.csv;*.hmk|CSV Files|*.csv|HMK Files|*.hmk|All Files|*.*";
      if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        CSVTextBox.Text = File.ReadAllText(d.FileName);
      }
    }

    private void parseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Convert();
    }

    private void Convert()
    {
      MCPTextBox.Clear();
      MCPTextBox.AppendText("COMMENT\r\n");
      MCPTextBox.AppendText("\r\n");
      MCPTextBox.AppendText("MEMORY DATA\r\n");

      foreach (string line in CSVTextBox.Lines)
      {
        if (line.StartsWith("0") && line[4] == ',')
        {
          MemoryChannel mc = new MemoryChannel();
          mc.LoadCSV(line);
          MCPTextBox.AppendText(mc.GetMCPData());
        }
      }
    }

    private void pasteCSVToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CSVTextBox.Clear();
      CSVTextBox.Paste();
      Convert();
      CopyMCP();
    }

    private void copyMCPToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CopyMCP();
    }

    private void CopyMCP()
    {
      UseWaitCursor = true;
      Application.DoEvents();
      MCPTextBox.SelectAll();
      MCPTextBox.Copy();
      System.Threading.Thread.Sleep(1000);
      UseWaitCursor = false;
    }
  }
}
