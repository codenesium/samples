using MediatR;
using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class TestAllFieldTypeService : AbstractTestAllFieldTypeService, ITestAllFieldTypeService
	{
		public TestAllFieldTypeService(
			ILogger<ITestAllFieldTypeRepository> logger,
			IMediator mediator,
			ITestAllFieldTypeRepository testAllFieldTypeRepository,
			IApiTestAllFieldTypeServerRequestModelValidator testAllFieldTypeModelValidator,
			IDALTestAllFieldTypeMapper dalTestAllFieldTypeMapper)
			: base(logger,
			       mediator,
			       testAllFieldTypeRepository,
			       testAllFieldTypeModelValidator,
			       dalTestAllFieldTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>222a7c491feda9bf0ebac4f1bfcbff07</Hash>
</Codenesium>*/