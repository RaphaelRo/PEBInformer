using System;
using System.Runtime.InteropServices;

namespace PEBInformerLib.Native
{
    // 64 BIT PEB
    //+0x000 InheritedAddressSpace : UChar
    //+0x001 ReadImageFileExecOptions : UChar
    //+0x002 BeingDebugged    : UChar
    //+0x003 BitField         : UChar
    //+0x003 ImageUsesLargePages : Pos 0, 1 Bit
    //+0x003 IsProtectedProcess : Pos 1, 1 Bit
    //+0x003 IsImageDynamicallyRelocated : Pos 2, 1 Bit
    //+0x003 SkipPatchingUser32Forwarders : Pos 3, 1 Bit
    //+0x003 IsPackagedProcess : Pos 4, 1 Bit
    //+0x003 IsAppContainer   : Pos 5, 1 Bit
    //+0x003 IsProtectedProcessLight : Pos 6, 1 Bit
    //+0x003 IsLongPathAwareProcess : Pos 7, 1 Bit
    //+0x004 Padding0         : [4] UChar
    //+0x008 Mutant           : Ptr64 Void
    //+0x010 ImageBaseAddress : Ptr64 Void
    //+0x018 Ldr              : Ptr64 _PEB_LDR_DATA
    //+0x020 ProcessParameters : Ptr64 _RTL_USER_PROCESS_PARAMETERS
    //+0x028 SubSystemData    : Ptr64 Void
    //+0x030 ProcessHeap      : Ptr64 Void
    //+0x038 FastPebLock      : Ptr64 _RTL_CRITICAL_SECTION
    //+0x040 AtlThunkSListPtr : Ptr64 _SLIST_HEADER
    //+0x048 IFEOKey          : Ptr64 Void
    //+0x050 CrossProcessFlags : Uint4B
    //+0x050 ProcessInJob     : Pos 0, 1 Bit
    //+0x050 ProcessInitializing : Pos 1, 1 Bit
    //+0x050 ProcessUsingVEH  : Pos 2, 1 Bit
    //+0x050 ProcessUsingVCH  : Pos 3, 1 Bit
    //+0x050 ProcessUsingFTH  : Pos 4, 1 Bit
    //+0x050 ProcessPreviouslyThrottled : Pos 5, 1 Bit
    //+0x050 ProcessCurrentlyThrottled : Pos 6, 1 Bit
    //+0x050 ProcessImagesHotPatched : Pos 7, 1 Bit
    //+0x050 ReservedBits0    : Pos 8, 24 Bits
    //+0x054 Padding1         : [4] UChar
    //+0x058 KernelCallbackTable : Ptr64 Void
    //+0x058 UserSharedInfoPtr : Ptr64 Void
    //+0x060 SystemReserved   : Uint4B
    //+0x064 AtlThunkSListPtr32 : Uint4B
    //+0x068 ApiSetMap        : Ptr64 Void
    //+0x070 TlsExpansionCounter : Uint4B
    //+0x074 Padding2         : [4] UChar
    //+0x078 TlsBitmap        : Ptr64 Void
    //+0x080 TlsBitmapBits    : [2] Uint4B
    //+0x088 ReadOnlySharedMemoryBase : Ptr64 Void
    //+0x090 SharedData       : Ptr64 Void
    //+0x098 ReadOnlyStaticServerData : Ptr64 Ptr64 Void
    //+0x0a0 AnsiCodePageData : Ptr64 Void
    //+0x0a8 OemCodePageData  : Ptr64 Void
    //+0x0b0 UnicodeCaseTableData : Ptr64 Void
    //+0x0b8 NumberOfProcessors : Uint4B
    //+0x0bc NtGlobalFlag     : Uint4B
    //+0x0c0 CriticalSectionTimeout : _LARGE_INTEGER
    //+0x0c8 HeapSegmentReserve : Uint8B
    //+0x0d0 HeapSegmentCommit : Uint8B
    //+0x0d8 HeapDeCommitTotalFreeThreshold : Uint8B
    //+0x0e0 HeapDeCommitFreeBlockThreshold : Uint8B
    //+0x0e8 NumberOfHeaps    : Uint4B
    //+0x0ec MaximumNumberOfHeaps : Uint4B
    //+0x0f0 ProcessHeaps     : Ptr64 Ptr64 Void
    //+0x0f8 GdiSharedHandleTable : Ptr64 Void
    //+0x100 ProcessStarterHelper : Ptr64 Void
    //+0x108 GdiDCAttributeList : Uint4B
    //+0x10c Padding3         : [4] UChar
    //+0x110 LoaderLock       : Ptr64 _RTL_CRITICAL_SECTION
    //+0x118 OSMajorVersion   : Uint4B
    //+0x11c OSMinorVersion   : Uint4B
    //+0x120 OSBuildNumber    : Uint2B
    //+0x122 OSCSDVersion     : Uint2B
    //+0x124 OSPlatformId     : Uint4B
    //+0x128 ImageSubsystem   : Uint4B
    //+0x12c ImageSubsystemMajorVersion : Uint4B
    //+0x130 ImageSubsystemMinorVersion : Uint4B
    //+0x134 Padding4         : [4] UChar
    //+0x138 ActiveProcessAffinityMask : Uint8B
    //+0x140 GdiHandleBuffer  : [60] Uint4B
    //+0x230 PostProcessInitRoutine : Ptr64 void 
    //+0x238 TlsExpansionBitmap : Ptr64 Void
    //+0x240 TlsExpansionBitmapBits : [32] Uint4B
    //+0x2c0 SessionId        : Uint4B
    //+0x2c4 Padding5         : [4] UChar
    //+0x2c8 AppCompatFlags   : _ULARGE_INTEGER
    //+0x2d0 AppCompatFlagsUser : _ULARGE_INTEGER
    //+0x2d8 pShimData        : Ptr64 Void
    //+0x2e0 AppCompatInfo    : Ptr64 Void
    //+0x2e8 CSDVersion       : _UNICODE_STRING
    //+0x2f8 ActivationContextData : Ptr64 _ACTIVATION_CONTEXT_DATA
    //+0x300 ProcessAssemblyStorageMap : Ptr64 _ASSEMBLY_STORAGE_MAP
    //+0x308 SystemDefaultActivationContextData : Ptr64 _ACTIVATION_CONTEXT_DATA
    //+0x310 SystemAssemblyStorageMap : Ptr64 _ASSEMBLY_STORAGE_MAP
    //+0x318 MinimumStackCommit : Uint8B
    //+0x320 FlsCallback      : Ptr64 _FLS_CALLBACK_INFO
    //+0x328 FlsListHead      : _LIST_ENTRY
    //+0x338 FlsBitmap        : Ptr64 Void
    //+0x340 FlsBitmapBits    : [4] Uint4B
    //+0x350 FlsHighIndex     : Uint4B
    //+0x358 WerRegistrationData : Ptr64 Void
    //+0x360 WerShipAssertPtr : Ptr64 Void
    //+0x368 pUnused          : Ptr64 Void
    //+0x370 pImageHeaderHash : Ptr64 Void
    //+0x378 TracingFlags     : Uint4B
    //+0x378 HeapTracingEnabled : Pos 0, 1 Bit
    //+0x378 CritSecTracingEnabled : Pos 1, 1 Bit
    //+0x378 LibLoaderTracingEnabled : Pos 2, 1 Bit
    //+0x378 SpareTracingBits : Pos 3, 29 Bits
    //+0x37c Padding6         : [4] UChar
    //+0x380 CsrServerReadOnlySharedMemoryBase : Uint8B
    //+0x388 TppWorkerpListLock : Uint8B
    //+0x390 TppWorkerpList   : _LIST_ENTRY
    //+0x3a0 WaitOnAddressHashTable : [128]
    // Ptr64 Void
    //+0x7a0 TelemetryCoverageHeader : Ptr64 Void
    //+0x7a8 CloudFileFlags   : Uint4B
    //+0x7ac CloudFileDiagFlags : Uint4B
    //+0x7b0 PlaceholderCompatibilityMode : Char
    //+0x7b1 PlaceholderCompatibilityModeReserved : [7] Char
    //+0x7b8 LeapSecondData   : Ptr64 _LEAP_SECOND_DATA
    //+0x7c0 LeapSecondFlags  : Uint4B
    //+0x7c0 SixtySecondEnabled : Pos 0, 1 Bit
    //+0x7c0 Reserved         : Pos 1, 31 Bits
    //+0x7c4 NtGlobalFlag2    : Uint4B


    /// <summary>
    /// PEB
    /// https://docs.microsoft.com/en-us/windows/desktop/api/winternl/ns-winternl-_peb
    /// https://www.nirsoft.net/kernel_struct/vista/PEB.html
    /// found at FS:[0x30] in the TEB for 32-bit processes, 
    /// and it’s located at GS:[0x60] for 64-bit processes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
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

        private long _mutant;
        private long _imageBaseAddress;
        /// <summary>
        /// _PEB_LDR_DATA
        /// </summary>
        private long _loaderData;
        private long _processParameters;

        public byte InheritedAddressSpace => _inheritedAddressSpace;

        public byte ReadImageFileExecutionOptions => _readImageFileExecutionOptions;

        public byte BeingDebugged => _beingDebugged;

        public byte BitField => _bitField;

        public IntPtr Mutant => new IntPtr(_mutant);

        public IntPtr ImageBaseAddress => new IntPtr(_imageBaseAddress);

        public IntPtr LoaderData => new IntPtr(_loaderData);

        public IntPtr ProcessParameters => new IntPtr(_processParameters);
    };
}
