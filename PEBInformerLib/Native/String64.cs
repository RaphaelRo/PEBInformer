using System;
using System.Runtime.InteropServices;

namespace PEBInformerLib.Native
{
    /// <summary>
    /// _STRING  size: 0x10
    /// +0x000 Length           : Uint2B
    /// +0x002 MaximumLength    : Uint2B
    /// +0x008 Buffer           : Ptr64 Char
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x10)]
    public struct String64
    {
        public ushort Length;
        public ushort MaximumLength;
        private uint Padding;
        public IntPtr Buffer;
    }
}
