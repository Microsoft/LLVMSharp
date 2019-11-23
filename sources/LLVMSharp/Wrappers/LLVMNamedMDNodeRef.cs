// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMNamedMDNodeRef
    {
        public LLVMNamedMDNodeRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMNamedMDNodeRef(LLVMOpaqueNamedMDNode* value)
        {
            return new LLVMNamedMDNodeRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueNamedMDNode*(LLVMNamedMDNodeRef value)
        {
            return (LLVMOpaqueNamedMDNode*)value.Pointer;
        }
    }
}
