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
    string Title;
    public MainWindow()
    {
      InitializeComponent();
      Title = this.Text;
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
        MemoryChannel mc = new MemoryChannel();
        mc.LoadText(line);
        if (mc.Valid)
          MCPTextBox.AppendText(mc.GetMCPData());
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

    private void readToolStripMenuItem_Click(object sender, EventArgs e)
    {
      listView1.Items.Clear();
      CSVTextBox.Clear();
      Radio radio = new Radio();
      radio.SendCommand("FR0;");
      string response;
      radio.Open("COM3");
        for (int i = 0; i < 10; i++)
      {
        this.Text = Title + " - " + i.ToString("000");
        response = radio.ReadChannelRX(i);
        if (response.EndsWith("?"))
          response = radio.ReadChannelRX(i);

        MemoryChannel mc = new MemoryChannel();
        mc.LoadText(response);
        if (mc.RxFreqency != 0)
        {
          CSVTextBox.AppendText(response + ";\r\n");
          response = radio.ReadChannelTX(i);
          mc.LoadText(response);
          if (mc.TxFreqency != mc.RxFreqency && mc.TxFreqency != 0)
            CSVTextBox.AppendText(response + ";\r\n");
          ListAdd(mc);
        }
      }
      radio.Close();
      this.Text = Title;
    }

    void ListAdd(MemoryChannel MC)
    {
      ListViewItem item=new ListViewItem(MC.Channel.ToString());
      string format = "#,###,###,###";
      item.Tag = MC;
      item.SubItems.Add(MC.MemoryName);
      item.SubItems.Add(MC.RxFreqency.ToString(format));
      item.SubItems.Add(MC.TxFreqency.ToString(format));
      item.SubItems.Add(MC.Mode.ToString());
      item.SubItems.Add(MC.Lockout.ToString());
      item.SubItems.Add(MC.ToneMode.ToString());
      item.SubItems.Add(MC.TxTone.ToString());
      item.SubItems.Add(MC.RxTone.ToString());
      item.SubItems.Add(MC.DCSCode.ToString());
      item.SubItems.Add(MC.Reverse.ToString());
      item.SubItems.Add(MC.Shift.ToString());
      item.SubItems.Add(MC.OffsetFreq.ToString(format));
      item.SubItems.Add(MC.StepSize.ToString());
      item.SubItems.Add(MC.MemoryGroup.ToString());
      listView1.Items.Add(item);
    }
  }
}
