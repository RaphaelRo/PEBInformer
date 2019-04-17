using System;

namespace PEBInformerLib
{
    public interface IPeb
    {
        byte InheritedAddressSpace { get; }
        byte ReadImageFileExecutionOptions { get; }
        byte BeingDebugged { get; }
        byte BitField { get; }
        IntPtr Mutant { get; }
        IntPtr ImageBaseAddress { get; }
        IntPtr LoaderData { get; }
        IntPtr ProcessParameters { get; }
    }
}