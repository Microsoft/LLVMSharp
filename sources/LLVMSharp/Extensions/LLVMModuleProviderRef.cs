// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMModuleProviderRef : IEquatable<LLVMModuleProviderRef>
    {
        public static bool operator ==(LLVMModuleProviderRef left, LLVMModuleProviderRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMModuleProviderRef left, LLVMModuleProviderRef right) => !(left == right);

        public LLVMPassManagerRef CreateFunctionPassManager() => LLVM.CreateFunctionPassManager(this);

        public override bool Equals(object obj) => obj is LLVMModuleProviderRef other && Equals(other);

        public bool Equals(LLVMModuleProviderRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
