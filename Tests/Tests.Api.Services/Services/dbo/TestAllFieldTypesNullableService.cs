using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class TestAllFieldTypesNullableService : AbstractTestAllFieldTypesNullableService, ITestAllFieldTypesNullableService
	{
		public TestAllFieldTypesNullableService(
			ILogger<ITestAllFieldTypesNullableRepository> logger,
			ITestAllFieldTypesNullableRepository testAllFieldTypesNullableRepository,
			IApiTestAllFieldTypesNullableRequestModelValidator testAllFieldTypesNullableModelValidator,
			IBOLTestAllFieldTypesNullableMapper boltestAllFieldTypesNullableMapper,
			IDALTestAllFieldTypesNullableMapper daltestAllFieldTypesNullableMapper
			)
			: base(logger,
			       testAllFieldTypesNullableRepository,
			       testAllFieldTypesNullableModelValidator,
			       boltestAllFieldTypesNullableMapper,
			       daltestAllFieldTypesNullableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>42b70ed6f878fa9d5eb1f92a9fc00c2e</Hash>
</Codenesium>*/