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
    <Hash>3caf536d4abb06dce0eac71049ab3caa</Hash>
</Codenesium>*/