using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TS2K
{
  class MemoryChannel
  {
    public bool Valid = false;

    public int Channel;
    public int RxFreqency;
    public Modes Mode;
    public OnOff Lockout;
    public ToneModes ToneMode;
    public int RxTone;
    public int DCSCode;
    public OnOff Reverse;
    public ShiftModes Shift;
    public int OffsetFreq;
    public int StepSize;  // always use 0: 5kHz
    public int MemoryGroup;
    public string MemoryName;

    public int TxFreqency = 0;
    public int TxTone;

    public double[] PLTones = new double[] {
      0.0,
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

    public ToneModes GetToneMode(string Tone)
    {
      if (Tone.Length == 1)
      {
        int i = int.Parse(Tone);
        return (ToneModes)i;
      }

      switch (Tone.Trim())
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

    public void LoadText(string Text)
    {
      string[] parts = Text.Trim().Split(',');
      if (Text.StartsWith("MR"))
      {
        LoadMCPData(Text);
      }
      else if (parts.Length == 15 && GetFrequency(parts[1]) != 0)
      {
        LoadCSV(parts);
      }
    }

    private void LoadCSV(string[] parts)
    {
      Channel = GetInt(parts[0]);
      RxFreqency = GetFrequency(parts[1]);
      StepSize = 0;
      OffsetFreq = GetFrequency(parts[3]);
      ToneMode = GetToneMode(parts[4]);
      TxTone = GetToneNumber(parts[5]);
      RxTone = GetToneNumber(parts[6]);
      DCSCode = GetInt(parts[7]);
      Shift = GetShiftMode(parts[8]);
      Reverse = GetOnOff(parts[9]);
      Lockout = GetOnOff(parts[10]);
      Mode = GetMode(parts[11]);
      TxFreqency = GetFrequency(parts[12]);
      CalcSplit();
      //TXStepSize = GetInt(parts[13]);
      MemoryName = parts[14];
      if (MemoryName.Length > 8)
        MemoryName = MemoryName.Substring(0, 8);

      MemoryGroup = (int)Channel / 100;

      Valid = true;
    }

    /// <summary>
    /// Set repeater offsets based on TX Frequency (when it's set.)
    /// <para>The TS-2000 can only use repeater offsets that are multiples of 50kHz
    /// So we will calculate those when possible. When it's not possible, we
    /// will set split mode.</para>
    /// </summary>
    private void CalcSplit()
    {
      // Assume channels with a + or - shift are already valid
      if (Shift == ShiftModes.Plus || Shift == ShiftModes.Minus)
      {
        TxFreqency = 0;
        return;
      }

      // Channels marked as simplex don't need any processing, other than to make sure
      // we set them that way.
      if (TxFreqency == RxFreqency || TxFreqency == 0 || Shift == ShiftModes.Simplex)
      {
        Shift = ShiftModes.Simplex;
        if (TxFreqency < 150000000)
          OffsetFreq = 600000;
        else if (TxFreqency < 400000000)
          OffsetFreq = 1600000;
        else
          OffsetFreq = 5000000;
        return;
      }

      // Determine offset for split channels. Set a standard offset when it's possible
      // otherwise set split mode
      int offset = TxFreqency - RxFreqency;
      if (offset % 50000 == 0)
      {
        OffsetFreq = Math.Abs(offset);
        TxFreqency = 0;
        if (offset < 0)
          Shift = ShiftModes.Minus;
        else if (offset > 0)
          Shift = ShiftModes.Plus;
      }
    }

    private Modes GetMode(string p)
    {
      if (p.Length == 1)
      {
        int i = int.Parse(p);
        return (Modes)i;
      }

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

    private OnOff GetOnOff(string p)
    {
      switch (p)
      {
        case "0":
          return OnOff.Off;
        case "1":
          return OnOff.On;
        case "On":
          return OnOff.On;
        default:
          return OnOff.Off;
      }
    }

    private ShiftModes GetShiftMode(string p)
    {
      if (p.Length == 1)
      {
        int i = int.Parse(p);
        return (ShiftModes)i;
      }

      switch (p)
      {
        case "-":
          return ShiftModes.Minus;
        case "+":
          return ShiftModes.Plus;
        case "S":
          return ShiftModes.Split;
        default:
          return ShiftModes.Simplex;
      }
    }

    private int GetToneNumber(string p)
    {
      double toneFreq = 0;
      double.TryParse(p, out toneFreq);
      for (int i = 0; i < PLTones.Length; i++)
      {
        if (toneFreq == PLTones[i])
          return i;
      }
      return 0;
    }

    public string GetCSV()
    {
      return "";
    }

    public void LoadMCPData(string Text)
    {
      Channel = int.Parse(Text.Substring(3, 3));
      if (Text[2] == '0')  // receive channel
        RxFreqency = int.Parse(Text.Substring(6, 11));
      else if (Text[2] == '1') // transmit channel
        TxFreqency = int.Parse(Text.Substring(6, 11));
      Mode = GetMode(Text.Substring(17, 1));
      Lockout = GetOnOff(Text.Substring(18, 1));
      ToneMode = GetToneMode(Text.Substring(19, 1));
      RxTone = int.Parse(Text.Substring(20, 2));
      TxTone = int.Parse(Text.Substring(22, 2));
      DCSCode = int.Parse(Text.Substring(24, 3));
      Reverse = GetOnOff(Text.Substring(27, 1));
      Shift = GetShiftMode(Text.Substring(28, 1));
      OffsetFreq = int.Parse(Text.Substring(29, 9));
      StepSize = int.Parse(Text.Substring(38, 2));
      MemoryGroup = int.Parse(Text.Substring(40, 1));
      MemoryName = Text.Substring(41).TrimEnd(';');
      Valid = true;
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
      s.Append(OffsetFreq.ToString("000000000"));
      s.Append(((int)StepSize).ToString("00"));
      s.Append(((int)MemoryGroup).ToString("0"));
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
        s.Append(OffsetFreq.ToString("000000000"));
        s.Append(((int)StepSize).ToString("00"));
        s.Append(((int)MemoryGroup).ToString("0"));
        s.Append(MemoryName);
        s.AppendLine();
      }

      return s.ToString();
    }

  }
}
