// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace LLVMSharp.UnitTests
{
    public static class Utilities
    {
        public static void EnsurePropertiesWork(this object obj)
        {
            var map = new Dictionary<string, object>();
            foreach(var p in obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                map.Add(p.Name, p.GetValue(obj));
            }
        }

        public static LLVMValueRef AddFunction(this LLVMModuleRef module, LLVMTypeRef returnType, string name, LLVMTypeRef[] parameterTypes, Action<LLVMValueRef, LLVMBuilderRef> action)
        {
            var type = LLVMTypeRef.CreateFunction(returnType, parameterTypes);
            var func = module.AddFunction(name, type);
            var block = func.AppendBasicBlock(string.Empty);
            var builder = module.Context.CreateBuilder();
            builder.PositionAtEnd(block);
            action(func, builder);
            return func;
        }
    }
}
