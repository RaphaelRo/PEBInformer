using System;
using System.Runtime.InteropServices;

namespace PEBInformerLib.Native
{
    /// <summary>
    /// PEB
    /// https://docs.microsoft.com/en-us/windows/desktop/api/winternl/ns-winternl-_peb
    /// https://www.nirsoft.net/kernel_struct/vista/PEB.html
    /// found at FS:[0x30] in the TEB for 32-bit processes, 
    /// and it’s located at GS:[0x60] for 64-bit processes.
    /// 
    /// struct _PEB, 118 elements, 0x7c8 bytes
    ///+0x000 InheritedAddressSpace : UChar
    ///+0x001 ReadImageFileExecOptions : UChar
    ///+0x002 BeingDebugged    : UChar
    ///+0x003 BitField         : UChar
    ///+0x003 ImageUsesLargePages : Bitfield Pos 0, 1 Bit
    ///+0x003 IsProtectedProcess : Bitfield Pos 1, 1 Bit
    ///+0x003 IsImageDynamicallyRelocated : Bitfield Pos 2, 1 Bit
    ///+0x003 SkipPatchingUser32Forwarders : Bitfield Pos 3, 1 Bit
    ///+0x003 IsPackagedProcess : Bitfield Pos 4, 1 Bit
    ///+0x003 IsAppContainer   : Bitfield Pos 5, 1 Bit
    ///+0x003 IsProtectedProcessLight : Bitfield Pos 6, 1 Bit
    ///+0x003 IsLongPathAwareProcess : Bitfield Pos 7, 1 Bit
    ///+0x004 Padding0         : [4] UChar
    ///+0x008 Mutant           : Ptr64 to Void
    ///+0x010 ImageBaseAddress : Ptr64 to Void
    ///+0x018 Ldr              : Ptr64 to struct _PEB_LDR_DATA, 9 elements, 0x58 bytes
    ///+0x020 ProcessParameters : Ptr64 to struct _RTL_USER_PROCESS_PARAMETERS, 34 elements, 0x420 bytes
    ///+0x028 SubSystemData    : Ptr64 to Void
    ///+0x030 ProcessHeap      : Ptr64 to Void
    ///+0x038 FastPebLock      : Ptr64 to struct _RTL_CRITICAL_SECTION, 6 elements, 0x28 bytes
    ///+0x040 AtlThunkSListPtr : Ptr64 to union _SLIST_HEADER, 3 elements, 0x10 bytes
    ///+0x048 IFEOKey          : Ptr64 to Void
    ///+0x050 CrossProcessFlags : Uint4B
    ///+0x050 ProcessInJob     : Bitfield Pos 0, 1 Bit
    ///+0x050 ProcessInitializing : Bitfield Pos 1, 1 Bit
    ///+0x050 ProcessUsingVEH  : Bitfield Pos 2, 1 Bit
    ///+0x050 ProcessUsingVCH  : Bitfield Pos 3, 1 Bit
    ///+0x050 ProcessUsingFTH  : Bitfield Pos 4, 1 Bit
    ///+0x050 ProcessPreviouslyThrottled : Bitfield Pos 5, 1 Bit
    ///+0x050 ProcessCurrentlyThrottled : Bitfield Pos 6, 1 Bit
    ///+0x050 ProcessImagesHotPatched : Bitfield Pos 7, 1 Bit
    ///+0x050 ReservedBits0    : Bitfield Pos 8, 24 Bits
    ///+0x054 Padding1         : [4] UChar
    ///+0x058 KernelCallbackTable : Ptr64 to Void
    ///+0x058 UserSharedInfoPtr : Ptr64 to Void
    ///+0x060 SystemReserved   : Uint4B
    ///+0x064 AtlThunkSListPtr32 : Uint4B
    ///+0x068 ApiSetMap        : Ptr64 to Void
    ///+0x070 TlsExpansionCounter : Uint4B
    ///+0x074 Padding2         : [4] UChar
    ///+0x078 TlsBitmap        : Ptr64 to Void
    ///+0x080 TlsBitmapBits    : [2] Uint4B
    ///+0x088 ReadOnlySharedMemoryBase : Ptr64 to Void
    ///+0x090 SharedData       : Ptr64 to Void
    ///+0x098 ReadOnlyStaticServerData : Ptr64 to Ptr64 to Void
    ///+0x0a0 AnsiCodePageData : Ptr64 to Void
    ///+0x0a8 OemCodePageData  : Ptr64 to Void
    ///+0x0b0 UnicodeCaseTableData : Ptr64 to Void
    ///+0x0b8 NumberOfProcessors : Uint4B
    ///+0x0bc NtGlobalFlag     : Uint4B
    ///+0x0c0 CriticalSectionTimeout : union _LARGE_INTEGER, 4 elements, 0x8 bytes
    ///+0x0c8 HeapSegmentReserve : Uint8B
    ///+0x0d0 HeapSegmentCommit : Uint8B
    ///+0x0d8 HeapDeCommitTotalFreeThreshold : Uint8B
    ///+0x0e0 HeapDeCommitFreeBlockThreshold : Uint8B
    ///+0x0e8 NumberOfHeaps    : Uint4B
    ///+0x0ec MaximumNumberOfHeaps : Uint4B
    ///+0x0f0 ProcessHeaps     : Ptr64 to Ptr64 to Void
    ///+0x0f8 GdiSharedHandleTable : Ptr64 to Void
    ///+0x100 ProcessStarterHelper : Ptr64 to Void
    ///+0x108 GdiDCAttributeList : Uint4B
    ///+0x10c Padding3         : [4] UChar
    ///+0x110 LoaderLock       : Ptr64 to struct _RTL_CRITICAL_SECTION, 6 elements, 0x28 bytes
    ///+0x118 OSMajorVersion   : Uint4B
    ///+0x11c OSMinorVersion   : Uint4B
    ///+0x120 OSBuildNumber    : Uint2B
    ///+0x122 OSCSDVersion     : Uint2B
    ///+0x124 OSPlatformId     : Uint4B
    ///+0x128 ImageSubsystem   : Uint4B
    ///+0x12c ImageSubsystemMajorVersion : Uint4B
    ///+0x130 ImageSubsystemMinorVersion : Uint4B
    ///+0x134 Padding4         : [4] UChar
    ///+0x138 ActiveProcessAffinityMask : Uint8B
    ///+0x140 GdiHandleBuffer  : [60] Uint4B
    ///+0x230 PostProcessInitRoutine : Ptr64 to     void 
    ///+0x238 TlsExpansionBitmap : Ptr64 to Void
    ///+0x240 TlsExpansionBitmapBits : [32] Uint4B
    ///+0x2c0 SessionId        : Uint4B
    ///+0x2c4 Padding5         : [4] UChar
    ///+0x2c8 AppCompatFlags   : union _ULARGE_INTEGER, 4 elements, 0x8 bytes
    ///+0x2d0 AppCompatFlagsUser : union _ULARGE_INTEGER, 4 elements, 0x8 bytes
    ///+0x2d8 pShimData        : Ptr64 to Void
    ///+0x2e0 AppCompatInfo    : Ptr64 to Void
    ///+0x2e8 CSDVersion       : struct _UNICODE_STRING, 3 elements, 0x10 bytes
    ///+0x2f8 ActivationContextData : Ptr64 to struct _ACTIVATION_CONTEXT_DATA, 0 elements, 0x0 bytes
    ///+0x300 ProcessAssemblyStorageMap : Ptr64 to struct _ASSEMBLY_STORAGE_MAP, 0 elements, 0x0 bytes
    ///+0x308 SystemDefaultActivationContextData : Ptr64 to struct _ACTIVATION_CONTEXT_DATA, 0 elements, 0x0 bytes
    ///+0x310 SystemAssemblyStorageMap : Ptr64 to struct _ASSEMBLY_STORAGE_MAP, 0 elements, 0x0 bytes
    ///+0x318 MinimumStackCommit : Uint8B
    ///+0x320 FlsCallback      : Ptr64 to struct _FLS_CALLBACK_INFO, 0 elements, 0x0 bytes
    ///+0x328 FlsListHead      : struct _LIST_ENTRY, 2 elements, 0x10 bytes
    ///+0x338 FlsBitmap        : Ptr64 to Void
    ///+0x340 FlsBitmapBits    : [4] Uint4B
    ///+0x350 FlsHighIndex     : Uint4B
    ///+0x358 WerRegistrationData : Ptr64 to Void
    ///+0x360 WerShipAssertPtr : Ptr64 to Void
    ///+0x368 pUnused          : Ptr64 to Void
    ///+0x370 pImageHeaderHash : Ptr64 to Void
    ///+0x378 TracingFlags     : Uint4B
    ///+0x378 HeapTracingEnabled : Bitfield Pos 0, 1 Bit
    ///+0x378 CritSecTracingEnabled : Bitfield Pos 1, 1 Bit
    ///+0x378 LibLoaderTracingEnabled : Bitfield Pos 2, 1 Bit
    ///+0x378 SpareTracingBits : Bitfield Pos 3, 29 Bits
    ///+0x37c Padding6         : [4] UChar
    ///+0x380 CsrServerReadOnlySharedMemoryBase : Uint8B
    ///+0x388 TppWorkerpListLock : Uint8B
    ///+0x390 TppWorkerpList   : struct _LIST_ENTRY, 2 elements, 0x10 bytes
    ///+0x3a0 WaitOnAddressHashTable : [128] Ptr64 to Void
    ///+0x7a0 TelemetryCoverageHeader : Ptr64 to Void
    ///+0x7a8 CloudFileFlags   : Uint4B
    ///+0x7ac CloudFileDiagFlags : Uint4B
    ///+0x7b0 PlaceholderCompatibilityMode : Char
    ///+0x7b1 PlaceholderCompatibilityModeReserved : [7] Char
    ///+0x7b8 LeapSecondData   : Ptr64 to struct _LEAP_SECOND_DATA, 3 elements, 0x10 bytes
    ///+0x7c0 LeapSecondFlags  : Uint4B
    ///+0x7c0 SixtySecondEnabled : Bitfield Pos 0, 1 Bit
    ///+0x7c0 Reserved         : Bitfield Pos 1, 31 Bits
    ///+0x7c4 NtGlobalFlag2    : Uint4B
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x7c8)]
    public struct Peb64 : IPeb
    {
        private byte _inheritedAddressSpace;
        private byte _readImageFileExecutionOptions;
        private byte _beingDebugged;
        /// <summary>
        /// Cannot write to these fields in the PEB structure and have the changes take effect because it won’t update EPROCESS
        /// ImageUsesLargePages : Pos 0, 1 Bit
        /// IsProtectedProcess : Pos 1, 1 Bit
        /// IsImageDynamicallyRelocated : Pos 2, 1 Bit
        /// SkipPatchingUser32Forwarders : Pos 3, 1 Bit
        /// IsPackagedProcess : Pos 4, 1 Bit
        /// IsAppContainer   : Pos 5, 1 Bit
        /// IsProtectedProcessLight : Pos 6, 1 Bit
        /// IsLongPathAwareProcess : Pos 7, 1 Bit
        /// </summary>
        private byte _bitField;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // Uchr[4]
        private byte[] _padding0;
        private IntPtr _mutant;
        private IntPtr _imageBaseAddress;
        private IntPtr _loaderData; // _PEB_LDR_DATA
        private IntPtr _processParameters;
        private IntPtr _subSystemData;
        private IntPtr _processHeap;
        private IntPtr _fastPebLock;
        private IntPtr _atlThunkSListPtr;
        private IntPtr _iFEOKey;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // Uint4B
        private byte[] _crossProcessFlags;
        // ProcessInJob     : Bitfield Pos 0, 1 Bit
        // ProcessInitializing : Bitfield Pos 1, 1 Bit
        // ProcessUsingVEH  : Bitfield Pos 2, 1 Bit
        // ProcessUsingVCH  : Bitfield Pos 3, 1 Bit
        // ProcessUsingFTH  : Bitfield Pos 4, 1 Bit
        // ProcessPreviouslyThrottled : Bitfield Pos 5, 1 Bit
        // ProcessCurrentlyThrottled : Bitfield Pos 6, 1 Bit
        // ProcessImagesHotPatched : Bitfield Pos 7, 1 Bit
        // ReservedBits0    : Bitfield Pos 8, 24 Bits
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // Uchr[4]
        private byte[] _padding1;
        private IntPtr _userSharedInfoPtr; // _kernelCallbackTable
        private uint _systemReserved;
        private uint _atlThunkSListPtr32;
        private IntPtr _apiSetMap;
        private uint _tlsExpansionCounter;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // Uchr[4]
        private byte[] _padding2;
        private IntPtr _tlsBitmap;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private uint[] _tlsBitmapBits;
        private IntPtr _readOnlySharedMemoryBase;
        private IntPtr _sharedData;
        private IntPtr _readOnlyStaticServerData;//: Ptr64 to Ptr64 to Void
        private IntPtr _ansiCodePageData;
        private IntPtr _oemCodePageData;
        private IntPtr _unicodeCaseTableData;
        private uint _numberOfProcessors;
        private uint _ntGlobalFlag;
        private ulong _criticalSectionTimeout; //: union _LARGE_INTEGER, 4 elements, 0x8 bytes
        private ulong _heapSegmentReserve;
        private ulong _heapSegmentCommit;
        private ulong _heapDeCommitTotalFreeThreshold;
        private ulong _heapDeCommitFreeBlockThreshold;
        private uint _numberOfHeaps;
        private uint _maximumNumberOfHeaps;
        private IntPtr _processHeaps;     //: Ptr64 to Ptr64 to Void
        private IntPtr _gdiSharedHandleTable;
        private IntPtr _processStarterHelper;
        private uint _gdiDCAttributeList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // Uchr[4]
        private byte[] _padding3;
        private IntPtr _loaderLock;       //: Ptr64 to struct _RTL_CRITICAL_SECTION, 6 elements, 0x28 bytes
        private uint _oSMajorVersion;
        private uint _oSMinorVersion;
        private ushort _oSBuildNumber;
        private ushort _oSCSDVersion;
        private uint _oSPlatformId;
        private uint _imageSubsystem;
        private uint _imageSubsystemMajorVersion;
        private uint _imageSubsystemMinorVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // Uchr[4]
        private byte[] _padding4;
        private ulong _activeProcessAffinityMask;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)] // Uint4B[60]
        private uint[] _gdiHandleBuffer;
        private IntPtr _postProcessInitRoutine;
        private IntPtr _tlsExpansionBitmap;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] // Uint4B[32]
        private uint[] _tlsExpansionBitmapBits;
        private uint _sessionId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // Uchr[4]
        private byte[] _padding5;
        private ulong _appCompatFlags; //: union _ULARGE_INTEGER, 4 elements, 0x8 bytes
        private ulong _appCompatFlagsUser; //: union _ULARGE_INTEGER, 4 elements, 0x8 bytes
        private IntPtr _pShimData;
        private IntPtr _appCompatInfo;
        private UnicodeString64 _cSDVersion;
        private IntPtr _activationContextData; //: Ptr64 to struct _ACTIVATION_CONTEXT_DATA, 0 elements, 0x0 bytes
        private IntPtr _processAssemblyStorageMap; //: Ptr64 to struct _ASSEMBLY_STORAGE_MAP, 0 elements, 0x0 bytes
        private IntPtr _systemDefaultActivationContextData; //: Ptr64 to struct _ACTIVATION_CONTEXT_DATA, 0 elements, 0x0 bytes
        private IntPtr _systemAssemblyStorageMap; // : Ptr64 to struct _ASSEMBLY_STORAGE_MAP, 0 elements, 0x0 bytes
        private ulong _minimumStackCommit;
        private IntPtr _flsCallback; //: Ptr64 to struct _FLS_CALLBACK_INFO, 0 elements, 0x0 bytes
        private ListEntry _flsListHead;
        private IntPtr _flsBitmap;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // Uint4B[4]
        private uint[] _flsBitmapBits;
        private uint _flsHighIndex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // Uint4B[4]
        private byte[] _unnamedPadding;
        private IntPtr _werRegistrationData;
        private IntPtr _werShipAssertPtr;
        private IntPtr _pUnused;
        private IntPtr _pImageHeaderHash;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _tracingFlags;
        /// _heapTracingEnabled : Bitfield Pos 0, 1 Bit
        /// _critSecTracingEnabled : Bitfield Pos 1, 1 Bit
        /// _libLoaderTracingEnabled : Bitfield Pos 2, 1 Bit
        /// _spareTracingBits : Bitfield Pos 3, 29 Bits
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // Uchr[4]
        private byte[] _padding6;
        private ulong _csrServerReadOnlySharedMemoryBase;
        private ulong _tppWorkerpListLock;
        private ListEntry _tppWorkerpList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] // Ptr64 to Void [128]
        private IntPtr[] _waitOnAddressHashTable;
        private IntPtr _telemetryCoverageHeader;
        private uint _cloudFileFlags;
        private uint _cloudFileDiagFlags;

        private byte _placeholderCompatibilityMode; //: Char
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =7)]
        private byte[] _placeholderCompatibilityModeReserved; //: [7] Char
        private IntPtr _leapSecondData;   //: Ptr64 to struct _LEAP_SECOND_DATA, 3 elements, 0x10 bytes
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _leapSecondFlags;
        // _sixtySecondEnabled : Bitfield Pos 0, 1 Bit
        // _reserved         : Bitfield Pos 1, 31 Bits
        private uint _ntGlobalFlag2;

        #region IPeb

        public byte InheritedAddressSpace => _inheritedAddressSpace;

        public byte ReadImageFileExecutionOptions => _readImageFileExecutionOptions;

        public byte BeingDebugged => _beingDebugged;

        public byte BitField => _bitField;

        public bool ImageUsesLargePages => _bitField.GetBitValue(0);
        public bool IsProtectedProcess => _bitField.GetBitValue(1);
        public bool IsImageDynamicallyRelocated => _bitField.GetBitValue(2);
        public bool SkipPatchingUser32Forwarders => _bitField.GetBitValue(3);
        public bool IsPackagedProcess => _bitField.GetBitValue(4);
        public bool IsAppContainer => _bitField.GetBitValue(5);
        public bool IsProtectedProcessLight => _bitField.GetBitValue(6);
        public bool IsLongPathAwareProcess => _bitField.GetBitValue(7);

        public IntPtr Mutant => _mutant;

        public IntPtr ImageBaseAddress => _imageBaseAddress;

        public IntPtr LoaderData => _loaderData;

        public IntPtr ProcessParameters => _processParameters;

        #endregion
    };
}
