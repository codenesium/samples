using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
	public partial class TestAllFieldTypesNullableRepository : AbstractTestAllFieldTypesNullableRepository, ITestAllFieldTypesNullableRepository
	{
		public TestAllFieldTypesNullableRepository(
			ILogger<TestAllFieldTypesNullableRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>965b6a8515079bbf54e3d5edcd0c454f</Hash>
</Codenesium>*/