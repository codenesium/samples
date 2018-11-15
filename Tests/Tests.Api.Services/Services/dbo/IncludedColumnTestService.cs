using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class IncludedColumnTestService : AbstractIncludedColumnTestService, IIncludedColumnTestService
	{
		public IncludedColumnTestService(
			ILogger<IIncludedColumnTestRepository> logger,
			IIncludedColumnTestRepository includedColumnTestRepository,
			IApiIncludedColumnTestServerRequestModelValidator includedColumnTestModelValidator,
			IBOLIncludedColumnTestMapper bolIncludedColumnTestMapper,
			IDALIncludedColumnTestMapper dalIncludedColumnTestMapper)
			: base(logger,
			       includedColumnTestRepository,
			       includedColumnTestModelValidator,
			       bolIncludedColumnTestMapper,
			       dalIncludedColumnTestMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1c0e56c50a2e785189c629ade904cd2e</Hash>
</Codenesium>*/