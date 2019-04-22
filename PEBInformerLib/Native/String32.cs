using System;
using System.Runtime.InteropServices;

namespace PEBInformerLib.Native
{
    /// <summary>
    /// _STRING  size : 0x8
    /// +0x000 Length           : Uint2B
    /// +0x002 MaximumLength    : Uint2B
    /// +0x004 Buffer           : Ptr32 Char
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x8)]
    public struct String32
    {
        public ushort Length;
        public ushort MaximumLength;
        public IntPtr Buffer;
    }
}
