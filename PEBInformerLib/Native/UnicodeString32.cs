using System;
using System.Runtime.InteropServices;

namespace PEBInformerLib.Native
{
    /// <summary>
    /// UNICODE_STRING : Size(8)
    /// 0x000 Length           : Uint2B
    /// 0x002 MaximumLength    : Uint2B
    /// 0x004 Buffer           : Ptr32 Wchar
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct UnicodeString32
    {
        /// <summary>
        /// length of the string in bytes
        /// not including the null-terminator
        /// </summary>
        private ushort _length;
        /// <summary>
        /// total allocated size
        /// </summary>
        private ushort _maximumLength;

        private IntPtr _buffer;

        public ushort Length => _length;
        public ushort MaximumLength => _maximumLength;
        public IntPtr Buffer => _buffer;
    }
}
