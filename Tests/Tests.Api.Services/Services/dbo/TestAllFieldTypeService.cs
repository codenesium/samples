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
			IBOLTestAllFieldTypeMapper bolTestAllFieldTypeMapper,
			IDALTestAllFieldTypeMapper dalTestAllFieldTypeMapper)
			: base(logger,
			       mediator,
			       testAllFieldTypeRepository,
			       testAllFieldTypeModelValidator,
			       bolTestAllFieldTypeMapper,
			       dalTestAllFieldTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>354ed4178b42c5b08b257dbcf67e1def</Hash>
</Codenesium>*/