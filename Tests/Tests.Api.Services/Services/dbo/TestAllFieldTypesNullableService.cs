using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class TestAllFieldTypesNullableService : AbstractTestAllFieldTypesNullableService, ITestAllFieldTypesNullableService
	{
		public TestAllFieldTypesNullableService(
			ILogger<ITestAllFieldTypesNullableRepository> logger,
			ITestAllFieldTypesNullableRepository testAllFieldTypesNullableRepository,
			IApiTestAllFieldTypesNullableServerRequestModelValidator testAllFieldTypesNullableModelValidator,
			IBOLTestAllFieldTypesNullableMapper bolTestAllFieldTypesNullableMapper,
			IDALTestAllFieldTypesNullableMapper dalTestAllFieldTypesNullableMapper)
			: base(logger,
			       testAllFieldTypesNullableRepository,
			       testAllFieldTypesNullableModelValidator,
			       bolTestAllFieldTypesNullableMapper,
			       dalTestAllFieldTypesNullableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>999061f0fb8d2ff012f4becc625325f7</Hash>
</Codenesium>*/