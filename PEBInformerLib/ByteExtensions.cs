using System;
using System.Collections;

namespace PEBInformerLib
{
    internal static class ByteExtensions
    {
        public static bool GetBitValue(this byte aByte, int index)
        {
            if (index < 0 || index > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return new BitArray(new byte[1] { aByte }).Get(index);
        }
    }
}
