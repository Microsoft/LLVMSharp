// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMErrorRef
    {
        public LLVMErrorRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMErrorRef(LLVMOpaqueError* value)
        {
            return new LLVMErrorRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueError*(LLVMErrorRef value)
        {
            return (LLVMOpaqueError*)value.Pointer;
        }
    }
}
