using System;

namespace PEBInformerLib
{
    public interface IPeb
    {
        byte InheritedAddressSpace { get; }
        byte ReadImageFileExecutionOptions { get; }
        byte BeingDebugged { get; }

        #region BitField

        byte BitField { get; }

        bool ImageUsesLargePages { get; }
        bool IsProtectedProcess { get; }
        bool IsImageDynamicallyRelocated { get; }
        bool SkipPatchingUser32Forwarders { get; }
        bool IsPackagedProcess { get; }
        bool IsAppContainer { get; }
        bool IsProtectedProcessLight { get; }
        bool IsLongPathAwareProcess { get; }

        #endregion

        IntPtr Mutant { get; }
        IntPtr ImageBaseAddress { get; }
        IntPtr LoaderData { get; }
        IntPtr ProcessParameters { get; }
    }
}