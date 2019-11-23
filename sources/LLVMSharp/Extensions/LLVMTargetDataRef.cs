// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public partial struct LLVMTargetDataRef : IEquatable<LLVMTargetDataRef>
    {
        public static bool operator ==(LLVMTargetDataRef left, LLVMTargetDataRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMTargetDataRef left, LLVMTargetDataRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMTargetDataRef other && Equals(other);

        public bool Equals(LLVMTargetDataRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
