using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMPassManagerBuilderRef
    {
        public LLVMPassManagerBuilderRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMPassManagerBuilderRef(LLVMOpaquePassManagerBuilder* value)
        {
            return new LLVMPassManagerBuilderRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaquePassManagerBuilder*(LLVMPassManagerBuilderRef value)
        {
            return (LLVMOpaquePassManagerBuilder*)value.Pointer;
        }
    }
}
