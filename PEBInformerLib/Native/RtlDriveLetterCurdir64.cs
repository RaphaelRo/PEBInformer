using System.Runtime.InteropServices;

namespace PEBInformerLib.Native
{
    /// <summary>
    /// _RTL_DRIVE_LETTER_CURDIR  size: 0x18
    /// +0x000 Flags            : Uint2B
    /// +0x002 Length           : Uint2B
    /// +0x004 TimeStamp        : Uint4B
    /// +0x008 DosPath          : _STRING
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x18)]
    public struct RtlDriveLetterCurdir64
    {
        public ushort Flags;
        public ushort Length;
        public uint TimeStamp;
        public String64 DosPath;
    }
}
