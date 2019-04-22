using System;
using System.Runtime.InteropServices;

namespace PEBInformerLib.Native
{
    /// <summary>
    /// struct _LIST_ENTRY, 2 elements, 0x10 bytes
    ///+0x000 Flink            : Ptr64 to struct _LIST_ENTRY, 2 elements, 0x10 bytes
    ///+0x008 Blink            : Ptr64 to struct _LIST_ENTRY, 2 elements, 0x10 bytes
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x10)]
    public struct ListEntry
    {
        public IntPtr Flink;
        public IntPtr Blink;
    }
}
