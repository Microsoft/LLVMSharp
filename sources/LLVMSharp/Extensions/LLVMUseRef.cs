using System;

namespace LLVMSharp
{
    public partial struct LLVMUseRef : IEquatable<LLVMUseRef>
    {
        public static bool operator ==(LLVMUseRef left, LLVMUseRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMUseRef left, LLVMUseRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMUseRef other && Equals(other);

        public bool Equals(LLVMUseRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
