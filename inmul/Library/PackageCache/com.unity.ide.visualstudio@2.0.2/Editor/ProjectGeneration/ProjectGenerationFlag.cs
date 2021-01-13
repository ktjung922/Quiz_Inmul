﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Unity.VisualStudio.Editor
{
	[Flags]
	public enum ProjectGenerationFlag
	{
		None = 0,
		Embedded = 1,
		Local = 2,
		Registry = 4,
		Git = 8,
		BuiltIn = 16,
		Unknown = 32,
		PlayerAssemblies = 64,
		LocalTarBall = 128,
	}
}
