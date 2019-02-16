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
			IDALTestAllFieldTypesNullableMapper dalTestAllFieldTypesNullableMapper)
			: base(logger,
			       mediator,
			       testAllFieldTypesNullableRepository,
			       testAllFieldTypesNullableModelValidator,
			       dalTestAllFieldTypesNullableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3f12acdbe6ea570c9c403b63da9a3661</Hash>
</Codenesium>*/