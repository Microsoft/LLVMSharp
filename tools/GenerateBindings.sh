cd ClangSharpPInvokeGenerator

if [ -z "$1" ]; then
  echo **ERROR**: LLVM Shared Library Location is required. A good value for this parameter is 'libLLVM' which will translate to 'libLLVM.dll'/'libLLVM.so'/'libLLVM.dylib' on their respective platforms.
  exit 1
fi
if [ -z "$2" ]; then
  echo **ERROR**: LLVM Include Directory is required. This is the directory which contains "llvm" and "llvm-c" as subdirectories
  exit 1
fi

dotnet run --m LLVM --p LLVM --namespace LLVMSharp --output Generated.tmp.cs --libraryPath $1 --include $2 --file $2/llvm-c/Analysis.h --file $2/llvm-c/BitReader.h --file $2/llvm-c/BitWriter.h --file $2/llvm-c/Core.h --file $2/llvm-c/Disassembler.h --file $2/llvm-c/ErrorHandling.h --file $2/llvm-c/ExecutionEngine.h --file $2/llvm-c/Initialization.h --file $2/llvm-c/IRReader.h --file $2/llvm-c/Linker.h --file $2/llvm-c/LinkTimeOptimizer.h --file $2/llvm-c/lto.h --file $2/llvm-c/Object.h --file $2/llvm-c/OrcBindings.h --file $2/llvm-c/Support.h --file $2/llvm-c/Target.h --file $2/llvm-c/TargetMachine.h --file $2/llvm-c/Types.h --file $2/llvm-c/Transforms/IPO.h --file $2/llvm-c/Transforms/PassManagerBuilder.h --file $2/llvm-c/Transforms/Scalar.h --file $2/llvm-c/Transforms/Vectorize.h --e LLVMDisasmInstruction --e LLVMGetBufferStart --e LLVMGetDiagInfoDescription --e LLVMGetDefaultTargetTriple --e LLVMCopyStringRepOfTargetData --e LLVMGetTargetMachineTriple --e LLVMGetTargetMachineCPU --e LLVMGetTargetMachineFeatureString --e LLVMPrintTypeToString --e LLVMCreateMessage --e LLVMDisposeMessage --e LLVMPrintModuleToString --e LLVMPrintValueToString --e LLVMOrcDisposeMangledSymbol --e LLVMTargetMachineEmitToFile --e LLVMInitializeCore

mv Generated.tmp.cs ..
cd ..