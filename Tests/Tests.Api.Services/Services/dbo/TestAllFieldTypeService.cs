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
    <Hash>1468ae1e2842a97ada2a558fd4a413d9</Hash>
</Codenesium>*/