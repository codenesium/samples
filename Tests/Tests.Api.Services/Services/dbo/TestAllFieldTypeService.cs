using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class TestAllFieldTypeService : AbstractTestAllFieldTypeService, ITestAllFieldTypeService
	{
		public TestAllFieldTypeService(
			ILogger<ITestAllFieldTypeRepository> logger,
			ITestAllFieldTypeRepository testAllFieldTypeRepository,
			IApiTestAllFieldTypeRequestModelValidator testAllFieldTypeModelValidator,
			IBOLTestAllFieldTypeMapper boltestAllFieldTypeMapper,
			IDALTestAllFieldTypeMapper daltestAllFieldTypeMapper
			)
			: base(logger,
			       testAllFieldTypeRepository,
			       testAllFieldTypeModelValidator,
			       boltestAllFieldTypeMapper,
			       daltestAllFieldTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a5890324b300e00a7cda8af158e43b10</Hash>
</Codenesium>*/