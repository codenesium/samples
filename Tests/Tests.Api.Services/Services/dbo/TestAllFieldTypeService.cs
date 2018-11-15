using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class TestAllFieldTypeService : AbstractTestAllFieldTypeService, ITestAllFieldTypeService
	{
		public TestAllFieldTypeService(
			ILogger<ITestAllFieldTypeRepository> logger,
			ITestAllFieldTypeRepository testAllFieldTypeRepository,
			IApiTestAllFieldTypeServerRequestModelValidator testAllFieldTypeModelValidator,
			IBOLTestAllFieldTypeMapper bolTestAllFieldTypeMapper,
			IDALTestAllFieldTypeMapper dalTestAllFieldTypeMapper)
			: base(logger,
			       testAllFieldTypeRepository,
			       testAllFieldTypeModelValidator,
			       bolTestAllFieldTypeMapper,
			       dalTestAllFieldTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b7c0d6e1ae0ca6e21e5763f4c3a05754</Hash>
</Codenesium>*/