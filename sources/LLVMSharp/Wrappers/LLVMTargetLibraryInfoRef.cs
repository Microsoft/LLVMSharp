// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMTargetLibraryInfoRef
    {
        public LLVMTargetLibraryInfoRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMTargetLibraryInfoRef(LLVMOpaqueTargetLibraryInfotData* value)
        {
            return new LLVMTargetLibraryInfoRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueTargetLibraryInfotData*(LLVMTargetLibraryInfoRef value)
        {
            return (LLVMOpaqueTargetLibraryInfotData*)value.Pointer;
        }
    }
}
