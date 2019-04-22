using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace PEBInformerLib.Native
{
    // 32Bit PEB
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
    //+0x004 Mutant           : Ptr32 Void
    //+0x008 ImageBaseAddress : Ptr32 Void
    //+0x00c Ldr              : Ptr32 _PEB_LDR_DATA
    //+0x010 ProcessParameters : Ptr32 _RTL_USER_PROCESS_PARAMETERS
    //+0x014 SubSystemData    : Ptr32 Void
    //+0x018 ProcessHeap      : Ptr32 Void
    //+0x01c FastPebLock      : Ptr32 _RTL_CRITICAL_SECTION
    //+0x020 AtlThunkSListPtr : Ptr32 _SLIST_HEADER
    //+0x024 IFEOKey          : Ptr32 Void
    //+0x028 CrossProcessFlags : Uint4B
    //+0x028 ProcessInJob     : Pos 0, 1 Bit
    //+0x028 ProcessInitializing : Pos 1, 1 Bit
    //+0x028 ProcessUsingVEH  : Pos 2, 1 Bit
    //+0x028 ProcessUsingVCH  : Pos 3, 1 Bit
    //+0x028 ProcessUsingFTH  : Pos 4, 1 Bit
    //+0x028 ProcessPreviouslyThrottled : Pos 5, 1 Bit
    //+0x028 ProcessCurrentlyThrottled : Pos 6, 1 Bit
    //+0x028 ProcessImagesHotPatched : Pos 7, 1 Bit
    //+0x028 ReservedBits0    : Pos 8, 24 Bits
    //+0x02c KernelCallbackTable : Ptr32 Void
    //+0x02c UserSharedInfoPtr : Ptr32 Void
    //+0x030 SystemReserved   : Uint4B
    //+0x034 AtlThunkSListPtr32 : Ptr32 _SLIST_HEADER
    //+0x038 ApiSetMap        : Ptr32 Void
    //+0x03c TlsExpansionCounter : Uint4B
    //+0x040 TlsBitmap        : Ptr32 Void
    //+0x044 TlsBitmapBits    : [2] Uint4B
    //+0x04c ReadOnlySharedMemoryBase : Ptr32 Void
    //+0x050 SharedData       : Ptr32 Void
    //+0x054 ReadOnlyStaticServerData : Ptr32 Ptr32 Void
    //+0x058 AnsiCodePageData : Ptr32 Void
    //+0x05c OemCodePageData  : Ptr32 Void
    //+0x060 UnicodeCaseTableData : Ptr32 Void
    //+0x064 NumberOfProcessors : Uint4B
    //+0x068 NtGlobalFlag     : Uint4B
    //+0x070 CriticalSectionTimeout : _LARGE_INTEGER
    //+0x078 HeapSegmentReserve : Uint4B
    //+0x07c HeapSegmentCommit : Uint4B
    //+0x080 HeapDeCommitTotalFreeThreshold : Uint4B
    //+0x084 HeapDeCommitFreeBlockThreshold : Uint4B
    //+0x088 NumberOfHeaps    : Uint4B
    //+0x08c MaximumNumberOfHeaps : Uint4B
    //+0x090 ProcessHeaps     : Ptr32 Ptr32 Void
    //+0x094 GdiSharedHandleTable : Ptr32 Void
    //+0x098 ProcessStarterHelper : Ptr32 Void
    //+0x09c GdiDCAttributeList : Uint4B
    //+0x0a0 LoaderLock       : Ptr32 _RTL_CRITICAL_SECTION
    //+0x0a4 OSMajorVersion   : Uint4B
    //+0x0a8 OSMinorVersion   : Uint4B
    //+0x0ac OSBuildNumber    : Uint2B
    //+0x0ae OSCSDVersion     : Uint2B
    //+0x0b0 OSPlatformId     : Uint4B
    //+0x0b4 ImageSubsystem   : Uint4B
    //+0x0b8 ImageSubsystemMajorVersion : Uint4B
    //+0x0bc ImageSubsystemMinorVersion : Uint4B
    //+0x0c0 ActiveProcessAffinityMask : Uint4B
    //+0x0c4 GdiHandleBuffer  : [34] Uint4B
    //+0x14c PostProcessInitRoutine : Ptr32 void 
    //+0x150 TlsExpansionBitmap : Ptr32 Void
    //+0x154 TlsExpansionBitmapBits : [32] Uint4B
    //+0x1d4 SessionId        : Uint4B
    //+0x1d8 AppCompatFlags   : _ULARGE_INTEGER
    //+0x1e0 AppCompatFlagsUser : _ULARGE_INTEGER
    //+0x1e8 pShimData        : Ptr32 Void
    //+0x1ec AppCompatInfo    : Ptr32 Void
    //+0x1f0 CSDVersion       : _UNICODE_STRING
    //+0x1f8 ActivationContextData : Ptr32 _ACTIVATION_CONTEXT_DATA
    //+0x1fc ProcessAssemblyStorageMap : Ptr32 _ASSEMBLY_STORAGE_MAP
    //+0x200 SystemDefaultActivationContextData : Ptr32 _ACTIVATION_CONTEXT_DATA
    //+0x204 SystemAssemblyStorageMap : Ptr32 _ASSEMBLY_STORAGE_MAP
    //+0x208 MinimumStackCommit : Uint4B
    //+0x20c FlsCallback      : Ptr32 _FLS_CALLBACK_INFO
    //+0x210 FlsListHead      : _LIST_ENTRY
    //+0x218 FlsBitmap        : Ptr32 Void
    //+0x21c FlsBitmapBits    : [4] Uint4B
    //+0x22c FlsHighIndex     : Uint4B
    //+0x230 WerRegistrationData : Ptr32 Void
    //+0x234 WerShipAssertPtr : Ptr32 Void
    //+0x238 pUnused          : Ptr32 Void
    //+0x23c pImageHeaderHash : Ptr32 Void
    //+0x240 TracingFlags     : Uint4B
    //+0x240 HeapTracingEnabled : Pos 0, 1 Bit
    //+0x240 CritSecTracingEnabled : Pos 1, 1 Bit
    //+0x240 LibLoaderTracingEnabled : Pos 2, 1 Bit
    //+0x240 SpareTracingBits : Pos 3, 29 Bits
    //+0x248 CsrServerReadOnlySharedMemoryBase : Uint8B
    //+0x250 TppWorkerpListLock : Uint4B
    //+0x254 TppWorkerpList   : _LIST_ENTRY
    //+0x25c WaitOnAddressHashTable : [128]
    // Ptr32 Void
    //+0x45c TelemetryCoverageHeader : Ptr32 Void
    //+0x460 CloudFileFlags   : Uint4B
    //+0x464 CloudFileDiagFlags : Uint4B
    //+0x468 PlaceholderCompatibilityMode : Char
    //+0x469 PlaceholderCompatibilityModeReserved : [7] Char
    //+0x470 LeapSecondData   : Ptr32 _LEAP_SECOND_DATA
    //+0x474 LeapSecondFlags  : Uint4B
    //+0x474 SixtySecondEnabled : Pos 0, 1 Bit
    //+0x474 Reserved         : Pos 1, 31 Bits
    //+0x478 NtGlobalFlag2    : Uint4B

    /// <summary>
    /// PEB
    /// https://docs.microsoft.com/en-us/windows/desktop/api/winternl/ns-winternl-_peb
    /// https://www.nirsoft.net/kernel_struct/vista/PEB.html
    /// found at FS:[0x30] in the TEB for 32-bit processes, 
    /// and it’s located at GS:[0x60] for 64-bit processes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Peb32 : IPeb
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
        private int _mutant;
        private int _imageBaseAddress;
        /// <summary>
        /// _PEB_LDR_DATA
        /// </summary>
        private int _loaderData;
        private int _processParameters;


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

        public IntPtr Mutant => new IntPtr(_mutant);
                      
        public IntPtr ImageBaseAddress => new IntPtr(_imageBaseAddress);
                      
        public IntPtr LoaderData => new IntPtr(_loaderData);
                      
        public IntPtr ProcessParameters => new IntPtr(_processParameters);

        #endregion

    };

}
