using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>442f65899b20b81d9e6da9635e88345d</Hash>
</Codenesium>*/