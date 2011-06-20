﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under MIT X11 license (for details please see \doc\license.txt)

using System;
using System.Linq;
using NUnit.Framework;

namespace ICSharpCode.NRefactory.CSharp.Parser.Expression
{
	[TestFixture]
	public class StackAllocExpressionTests
	{
		[Test]
		public void StackAllocExpressionTest()
		{
			var vd = ParseUtilCSharp.ParseStatement<VariableDeclarationStatement>("int* a = stackalloc int[100];");
			StackAllocExpression sae = (StackAllocExpression)vd.Variables.Single().Initializer;
			Assert.AreEqual("int", ((PrimitiveType)sae.Type).Keyword);
			Assert.AreEqual(100, ((PrimitiveExpression)sae.CountExpression).Value);
		}
	}
}
