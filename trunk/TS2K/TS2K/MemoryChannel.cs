using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TS2K
{
  class MemoryChannel
  {
    public int Channel;
    public int RxFreqency;
    public Modes Mode;
    public OnOff Lockout;
    public ToneModes ToneMode;
    public int RxTone;
    public int DCSCode;
    public OnOff Reverse;
    public Shifts Shift;
    public int OffsetFreq;
    public int StepSize;  // always use 0: 5kHz
    public int MemoryGroup;
    public string MemoryName;

    public int TxFreqency = 0;
    public int TxTone;

    public double[] PLTones = new double[] {
      67.0, 71.9, 74.4, 77.0, 79.7, 82.5, 85.4, 88.5, 91.5, 94.8, 
      97.4, 100.0, 103.5, 107.2, 110.9, 114.8, 118.8, 123.0, 127.3, 131.8,
      136.5, 141.3, 146.2, 151.4, 156.7, 162.2, 167.9, 173.8, 179.9, 186.2, 
      192.8, 203.5, 210.7, 218.1, 225.7, 233.6, 241.8, 250.3 };


    public int GetInt(string IntValue)
    {
      int v = 0;
      int.TryParse(IntValue, out v);
      return v;
    }

    public int GetFrequency(string Frequency)
    {
      decimal f = 0;
      decimal.TryParse(Frequency, out f);
      f = f * 1000000M;
      return (int)f;
    }

    public ToneModes GetToneMode(string T)
    {
      switch (T.Trim())
      {
        case "Off":
          return ToneModes.OFF;
        case "T":
          return ToneModes.TONE;
        case "CT":
          return ToneModes.CTCSS;
        case "D":
          return ToneModes.DCS;
        default:
          return ToneModes.OFF;
      }
    }

    public override string ToString()
    {
      return GetMCPData();
    }

    public void LoadCSV(string CSVText)
    {
      string[] parts = CSVText.Split(',');

      Channel = GetInt(parts[0]);
      RxFreqency = GetFrequency(parts[1]);
      StepSize = 0;
      OffsetFreq = GetFrequency(parts[3]);
      ToneMode = GetToneMode(parts[4]);
      TxTone = GetToneNumber(parts[5]);
      RxTone = GetToneNumber(parts[6]);
      DCSCode = GetInt(parts[7]);
      Shift = GetShiftMode(parts[8], parts[1], parts[12]);
      Reverse = GetOffOn(parts[9]);
      Lockout = GetOffOn(parts[10]);
      Mode = GetMode(parts[11]);
      TxFreqency = GetFrequency(parts[12]);
      CalcSplit();
      //TXStepSize = GetInt(parts[13]);
      MemoryName = parts[14];
      if (MemoryName.Length > 8)
        MemoryName = MemoryName.Substring(0, 8);
      
    }

    private void CalcSplit()
    {
      if (Shift == Shifts.Plus || Shift == Shifts.Minus)
      {
        TxFreqency = 0;
        return;
      }

      if (TxFreqency == RxFreqency)
        TxFreqency = 0;
      int offset = TxFreqency - RxFreqency;
      if (offset % 50000 == 0)
      {
        OffsetFreq = Math.Abs(offset);
        TxFreqency = 0;
        if (offset == 0)
          Shift = Shifts.Simplex;
        else if (offset < 0)
          Shift = Shifts.Minus;
        else if (offset > 0)
          Shift = Shifts.Plus;
      }
      else
      {
        Shift = Shifts.Simplex;
      }
    }

    private Modes GetMode(string p)
    {
      switch (p)
      {
        case "FM":
          return Modes.FM;
        case "AM":
          return Modes.AM;
        default:
          return Modes.FM;
      }
    }

    private OnOff GetOffOn(string p)
    {
      switch (p)
      {
        case "On":
          return OnOff.On;
        default:
          return OnOff.Off;
      }
    }

    private Shifts GetShiftMode(string p, string TXFreq, string RXFreq)
    {
      switch (p)
      {
        case "-":
          return Shifts.Minus;
        case "+":
          return Shifts.Plus;
        default:
          return Shifts.Simplex;
      }
    }

    private int GetToneNumber(string p)
    {
      double d = 0;
      double.TryParse(p, out d);
      for (int i = 0; i < PLTones.Length; i++)
      {
        if (d == PLTones[i])
          return i;
      }
      return 0;
    }

    public string GetCSV()
    {
      return "";
    }

    public void LoadMData(string MDataText)
    {
    }

    public string GetMCPData()
    {
      StringBuilder s = new StringBuilder();
      s.Append("0"); // RX/TX
      s.Append(Channel.ToString("000"));
      s.Append(RxFreqency.ToString("00000000000"));
      s.Append(((int)Mode).ToString("0"));
      s.Append(((int)Lockout).ToString("0"));
      s.Append(((int)ToneMode).ToString("0"));
      s.Append(TxTone.ToString("00"));
      s.Append(RxTone.ToString("00"));
      s.Append(DCSCode.ToString("000"));
      s.Append(((int)Reverse).ToString("0"));
      s.Append(((int)Shift).ToString("0"));
      s.Append(OffsetFreq.ToString("00000000000"));
      s.Append(((int)StepSize).ToString("0"));
      s.Append(MemoryName);
      s.AppendLine();

      if (TxFreqency != 0 && TxFreqency != RxFreqency)
      {
        s.Append("1"); // RX/TX
        s.Append(Channel.ToString("000"));
        s.Append(TxFreqency.ToString("00000000000"));
        s.Append(((int)Mode).ToString("0"));
        s.Append(((int)Lockout).ToString("0"));
        s.Append(((int)ToneMode).ToString("0"));
        s.Append(TxTone.ToString("00"));
        s.Append(RxTone.ToString("00"));
        s.Append(DCSCode.ToString("000"));
        s.Append(((int)Reverse).ToString("0"));
        s.Append(((int)Shift).ToString("0"));
        s.Append(OffsetFreq.ToString("00000000000"));
        s.Append(((int)StepSize).ToString("0"));
        s.Append(MemoryName);
        s.AppendLine();
      }

      return s.ToString();
    }

  }
}
