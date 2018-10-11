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
			IDALTestAllFieldTypesNullableMapper daltestAllFieldTypesNullableMapper)
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
    <Hash>32a658c09e8a890c24fbfe3a9b6e7ae7</Hash>
</Codenesium>*/