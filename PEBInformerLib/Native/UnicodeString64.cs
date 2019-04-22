using System;
using System.Runtime.InteropServices;

namespace PEBInformerLib.Native
{
    /// <summary>
    /// UNICODE_STRING size: 0x10
    ///+0x000 Length           : Uint2B
    ///+0x002 MaximumLength    : Uint2B
    ///+0x008 Buffer           : Ptr64 Wchar
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x10)]
    public struct UnicodeString64
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

        /// <summary>
        /// 4 bytes of padding.
        /// </summary>
        private uint _padding;

        private IntPtr _buffer;

        public ushort Length => _length;
        public ushort MaximumLength => _maximumLength;
        public IntPtr Buffer => _buffer;
    }
}
