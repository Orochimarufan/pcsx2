﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GSDumpGUI
{
    public class GIFRegFOG : GIFReg
    {
        public double F;

        static public GIFReg Unpack(UInt64 LowData, UInt64 HighData, bool PlainFormat)
        {
            GIFRegFOG u = new GIFRegFOG();
            u.Descriptor = GIFRegDescriptor.FOG;
            u.F = (UInt16)(GIFReg.GetBit(HighData, 36, 8));
            return u;
        }
    }
}