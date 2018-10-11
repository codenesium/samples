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
			IDALTestAllFieldTypeMapper daltestAllFieldTypeMapper)
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
    <Hash>1bffc979e7305ac80ead3e11cb688247</Hash>
</Codenesium>*/