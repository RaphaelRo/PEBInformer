using System;
using System.Runtime.InteropServices;

namespace PEBInformerLib.Native
{
    /// <summary>
    /// RTL_USER_PROCESS_PARAMETERS size: 0x420
    ///+0x000 MaximumLength    : Uint4B
    ///+0x004 Length           : Uint4B
    ///+0x008 Flags            : Uint4B
    ///+0x00c DebugFlags       : Uint4B
    ///+0x010 ConsoleHandle    : Ptr64 Void
    ///+0x018 ConsoleFlags     : Uint4B
    ///+0x020 StandardInput    : Ptr64 Void
    ///+0x028 StandardOutput   : Ptr64 Void
    ///+0x030 StandardError    : Ptr64 Void
    ///+0x038 CurrentDirectory : _CURDIR
    ///+0x050 DllPath          : _UNICODE_STRING
    ///+0x060 ImagePathName    : _UNICODE_STRING
    ///+0x070 CommandLine      : _UNICODE_STRING
    ///+0x080 Environment      : Ptr64 Void
    ///+0x088 StartingX        : Uint4B
    ///+0x08c StartingY        : Uint4B
    ///+0x090 CountX           : Uint4B
    ///+0x094 CountY           : Uint4B
    ///+0x098 CountCharsX      : Uint4B
    ///+0x09c CountCharsY      : Uint4B
    ///+0x0a0 FillAttribute    : Uint4B
    ///+0x0a4 WindowFlags      : Uint4B
    ///+0x0a8 ShowWindowFlags  : Uint4B
    ///+0x0b0 WindowTitle      : _UNICODE_STRING
    ///+0x0c0 DesktopInfo      : _UNICODE_STRING
    ///+0x0d0 ShellInfo        : _UNICODE_STRING
    ///+0x0e0 RuntimeData      : _UNICODE_STRING
    ///+0x0f0 CurrentDirectores : [32] _RTL_DRIVE_LETTER_CURDIR
    ///+0x3f0 EnvironmentSize  : Uint8B
    ///+0x3f8 EnvironmentVersion : Uint8B
    ///+0x400 PackageDependencyData : Ptr64 Void
    ///+0x408 ProcessGroupId   : Uint4B
    ///+0x40c LoaderThreads    : Uint4B
    ///+0x410 RedirectionDllName : _UNICODE_STRING
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x420)]
    public struct RtlUserProcessParameters64
    {
        public uint MaximumLength;
        public uint Length;
        public uint Flags;
        public uint DebugFlags;
        public IntPtr ConsoleHandle;
        public uint ConsoleFlags;
        private uint _padding1;
        public IntPtr StandardInput;
        public IntPtr StandardOutput;
        public IntPtr StandardError;
        public UnicodeString64 CurrentDirectoryPath;
        public IntPtr CurrentDirectory;
        public UnicodeString64 DllPath;
        public UnicodeString64 ImagePathName;
        public UnicodeString64 CommandLine;
        public IntPtr Environment;
        public uint StartingX;
        public uint StartingY;
        public uint CountX;
        public uint CountY;
        public uint CountCharsX;
        public uint CountCharsY;
        public uint FillAttribute;
        public uint WindowFlags;
        public uint ShowWindowFlags;
        private uint _padding2;
        public UnicodeString64 WindowTitle;
        public UnicodeString64 DesktopInfo;
        public UnicodeString64 ShellInfo;
        public UnicodeString64 RuntimeData;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public RtlDriveLetterCurdir64[] CurrentDirectores;
        public ulong EnvironmentSize;
        public ulong EnvironmentVersion;
        public IntPtr PackageDependencyData;
        public uint ProcessGroupId;
        public uint LoaderThreads;
        public UnicodeString64 RedirectionDllName;
    };
}
