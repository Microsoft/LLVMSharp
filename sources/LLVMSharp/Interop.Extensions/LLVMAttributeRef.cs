// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMAttributeRef : IEquatable<LLVMAttributeRef>
    {
        public LLVMAttributeRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMAttributeRef(LLVMOpaqueAttributeRef* value)
        {
            return new LLVMAttributeRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueAttributeRef*(LLVMAttributeRef value)
        {
            return (LLVMOpaqueAttributeRef*)value.Pointer;
        }

        public static bool operator ==(LLVMAttributeRef left, LLVMAttributeRef right) => left.Equals(right);

        public static bool operator !=(LLVMAttributeRef left, LLVMAttributeRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMAttributeRef other && Equals(other);

        public bool Equals(LLVMAttributeRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
