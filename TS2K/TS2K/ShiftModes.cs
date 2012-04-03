using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TS2K
{
  public enum ShiftModes
  {
    Simplex=0,
    Plus=1,
    Minus=2,
    /// <summary>
    /// Must be changed to Simplex, Plus, or Minus before writing to the radio
    /// </summary>
    Split=3,
  }
}
