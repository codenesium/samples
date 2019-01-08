using MediatR;
using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class TestAllFieldTypesNullableService : AbstractTestAllFieldTypesNullableService, ITestAllFieldTypesNullableService
	{
		public TestAllFieldTypesNullableService(
			ILogger<ITestAllFieldTypesNullableRepository> logger,
			IMediator mediator,
			ITestAllFieldTypesNullableRepository testAllFieldTypesNullableRepository,
			IApiTestAllFieldTypesNullableServerRequestModelValidator testAllFieldTypesNullableModelValidator,
			IBOLTestAllFieldTypesNullableMapper bolTestAllFieldTypesNullableMapper,
			IDALTestAllFieldTypesNullableMapper dalTestAllFieldTypesNullableMapper)
			: base(logger,
			       mediator,
			       testAllFieldTypesNullableRepository,
			       testAllFieldTypesNullableModelValidator,
			       bolTestAllFieldTypesNullableMapper,
			       dalTestAllFieldTypesNullableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>166fdcb3b11843ac4114920d2e0e0702</Hash>
</Codenesium>*/