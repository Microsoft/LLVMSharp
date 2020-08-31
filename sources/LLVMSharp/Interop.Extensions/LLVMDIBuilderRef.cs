// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMDIBuilderRef
    {
        public LLVMDIBuilderRef(IntPtr handle)
        {
            Handle = handle;
        }

        public IntPtr Handle;

        public LLVMMetadataRef CreateCompileUnit(LLVMDWARFSourceLanguage SourceLanguage, LLVMMetadataRef FileMetadata, string Producer, int IsOptimized, string Flags, uint RuntimeVersion,
            string SplitName, LLVMDWARFEmissionKind DwarfEmissionKind, uint DWOld, int SplitDebugInlining, int DebugInfoForProfiling) => CreateCompileUnit(SourceLanguage, FileMetadata, Producer.AsSpan(), IsOptimized, Flags.AsSpan(), RuntimeVersion, SplitName.AsSpan(), DwarfEmissionKind, DWOld, SplitDebugInlining, DebugInfoForProfiling);

        public LLVMMetadataRef CreateCompileUnit(LLVMDWARFSourceLanguage SourceLanguage, LLVMMetadataRef FileMetadata, ReadOnlySpan<char> Producer, int IsOptimized, ReadOnlySpan<char> Flags, uint RuntimeVersion,
            ReadOnlySpan<char> SplitName, LLVMDWARFEmissionKind DwarfEmissionKind, uint DWOld, int SplitDebugInlining, int DebugInfoForProfiling)
        {
            using var marshaledProducer= new MarshaledString(Producer);
            using var marshaledFlags = new MarshaledString(Flags);
            using var marshaledSplitNameFlags = new MarshaledString(SplitName);

            return LLVM.DIBuilderCreateCompileUnit(this, SourceLanguage, FileMetadata, marshaledProducer, (UIntPtr)marshaledProducer.Length, IsOptimized, marshaledFlags, (UIntPtr)marshaledFlags.Length,
                RuntimeVersion, marshaledSplitNameFlags, (UIntPtr)marshaledSplitNameFlags.Length, DwarfEmissionKind, DWOld, SplitDebugInlining, DebugInfoForProfiling);
        }

        public LLVMMetadataRef CreateFile(string FullPath, string Directory) => CreateFile(FullPath.AsSpan(), Directory.AsSpan());

        public LLVMMetadataRef CreateFile(ReadOnlySpan<char> FullPath, ReadOnlySpan<char> Directory)
        {
            using var marshaledFullPath = new MarshaledString(FullPath);
            using var marshaledDirectory = new MarshaledString(Directory);
            return LLVM.DIBuilderCreateFile(this, marshaledFullPath, (UIntPtr)marshaledFullPath.Length, marshaledDirectory, (UIntPtr)marshaledDirectory.Length);
        }

        public LLVMMetadataRef CreateFunction(LLVMMetadataRef Scope, string Name, string LinkageName, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Type, int IsLocalToUnit, int IsDefinition,
            uint ScopeLine, LLVMDIFlags Flags, int IsOptimized) => CreateFunction(Scope, Name.AsSpan(), LinkageName.AsSpan(), File, LineNo, Type, IsLocalToUnit, IsDefinition, ScopeLine, Flags, IsOptimized);

        public LLVMMetadataRef CreateFunction(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, ReadOnlySpan<char> LinkageName, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Type, int IsLocalToUnit, int IsDefinition,
            uint ScopeLine, LLVMDIFlags Flags, int IsOptimized)
        {
            using var marshaledName = new MarshaledString(Name);
            using var marshaledLinkageName = new MarshaledString(LinkageName);
            var methodNameLength = (uint)marshaledName.Length;
            var linkageNameLength = (uint)marshaledLinkageName.Length;

            return LLVM.DIBuilderCreateFunction(this, Scope, marshaledName, (UIntPtr)(methodNameLength), marshaledLinkageName, (UIntPtr)(linkageNameLength), File,
                LineNo, Type, IsLocalToUnit, IsDefinition, ScopeLine, Flags, IsOptimized);
        }

        public LLVMMetadataRef CreateMacro(LLVMMetadataRef ParentMacroFile, uint Line, LLVMDWARFMacinfoRecordType RecordType, string Name, string Value) => CreateMacro(ParentMacroFile, Line, RecordType, Name.AsSpan(), Value.AsSpan());

        public LLVMMetadataRef CreateMacro(LLVMMetadataRef ParentMacroFile, uint Line, LLVMDWARFMacinfoRecordType RecordType, ReadOnlySpan<char> Name, ReadOnlySpan<char> Value)
        {
            using var marshaledName = new MarshaledString(Name);
            using var marshaledValue = new MarshaledString(Value);
            var nameLength = (uint)marshaledName.Length;
            var valueLength = (uint)marshaledValue.Length;

            return LLVM.DIBuilderCreateMacro(this, ParentMacroFile, Line, RecordType, marshaledName, (UIntPtr)nameLength, marshaledValue, (UIntPtr)valueLength);
        }

        public LLVMMetadataRef CreateModule(LLVMMetadataRef ParentScope, string Name, string ConfigMacros, string IncludePath, string SysRoot) => CreateModule(ParentScope, Name.AsSpan(), ConfigMacros.AsSpan(), IncludePath.AsSpan(), SysRoot.AsSpan());

        public LLVMMetadataRef CreateModule(LLVMMetadataRef ParentScope, ReadOnlySpan<char> Name, ReadOnlySpan<char> ConfigMacros, ReadOnlySpan<char> IncludePath, ReadOnlySpan<char> SysRoot)
        {
            using var marshaledName = new MarshaledString(Name);
            using var marshaledConfigMacros = new MarshaledString(ConfigMacros);
            using var marshaledIncludePath = new MarshaledString(IncludePath);
            using var marshaledSysRoot = new MarshaledString(SysRoot);
            var nameLength = (uint)marshaledName.Length;
            var configMacrosLength = (uint)marshaledConfigMacros.Length;
            var includePathLength = (uint)marshaledIncludePath.Length;
            var sysRootLength = (uint)marshaledSysRoot.Length;

            return LLVM.DIBuilderCreateModule(this, ParentScope, marshaledName, (UIntPtr)nameLength, marshaledConfigMacros, (UIntPtr)configMacrosLength, marshaledIncludePath, (UIntPtr)includePathLength, marshaledSysRoot, (UIntPtr)sysRootLength);
        }

        public LLVMMetadataRef CreateSubroutineType(LLVMMetadataRef File, LLVMMetadataRef[] ParameterTypes, LLVMDIFlags Flags) => CreateSubroutineType(File, ParameterTypes.AsSpan(), Flags);

        public LLVMMetadataRef CreateSubroutineType(LLVMMetadataRef File, ReadOnlySpan<LLVMMetadataRef> ParameterTypes, LLVMDIFlags Flags)
        {
            fixed (LLVMMetadataRef* pParameterTypes = ParameterTypes)
            {
                return LLVM.DIBuilderCreateSubroutineType(this, File, (LLVMOpaqueMetadata**)pParameterTypes, (uint)ParameterTypes.Length, Flags);
            }
        }

        public LLVMMetadataRef CreateTempMacroFile(LLVMMetadataRef ParentMacroFile, uint Line, LLVMMetadataRef File) => LLVM.DIBuilderCreateTempMacroFile(this, ParentMacroFile, Line, File);

        public LLVMMetadataRef CreateTypedef(LLVMMetadataRef Type, string Name, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Scope, uint AlignInBits) => CreateTypedef(Type, Name.AsSpan(), File, LineNo, Scope, AlignInBits);

        public LLVMMetadataRef CreateTypedef(LLVMMetadataRef Type, ReadOnlySpan<char> Name, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Scope, uint AlignInBits)
        {
            using var marshaledName = new MarshaledString(Name);
            var nameLength = (uint)marshaledName.Length;

            return LLVM.DIBuilderCreateTypedef(this, Type, marshaledName, (UIntPtr)nameLength, File, LineNo, Scope, AlignInBits);
        }

        public static LLVMMetadataRef GetSubprogram(LLVMValueRef Function)
        {
            return LLVM.GetSubprogram(Function);
        }

        public static void SetSubprogram(LLVMValueRef Function, LLVMMetadataRef Type)
        {
            LLVM.SetSubprogram(Function, Type);
        }

        public void DIBuilderFinalize()
        {
            LLVM.DIBuilderFinalize(this);
        }

        public static implicit operator LLVMDIBuilderRef(LLVMOpaqueDIBuilder* value)
        {
            return new LLVMDIBuilderRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueDIBuilder*(LLVMDIBuilderRef value)
        {
            return (LLVMOpaqueDIBuilder*)value.Handle;
        }
    }
}
