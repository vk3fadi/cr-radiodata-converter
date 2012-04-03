using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TS2K
{
  class Radio
  {
    public System.IO.Ports.SerialPort Port;
    string[] PortList;

    public void Open(string PortName)
    {
      Port = new System.IO.Ports.SerialPort(PortName, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
      Port.RtsEnable = true;
      Port.DtrEnable = true;
      Port.Open();
    }

    public void Close()
    {
      Port.Close();
    }

    public Radio()
    {
      PortList = System.IO.Ports.SerialPort.GetPortNames();
    }

    public string SendCommand(string Message) {
      if (Port == null || Port.IsOpen == false)
        return "";

      Port.Write(Message);
      Port.ReadTimeout = 5000;
      string s = Port.ReadTo(";");
      return s;
    }

    public string ReadChannelRX(int ChannelNumber)
    {
      return SendCommand("MR0" + ChannelNumber.ToString("000") + ";");
    }

    public string ReadChannelTX(int ChannelNumber)
    {
      return SendCommand("MR1" + ChannelNumber.ToString("000") + ";");
    }
  }
}
