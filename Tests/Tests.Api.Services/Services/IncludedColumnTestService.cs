using MediatR;
using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class IncludedColumnTestService : AbstractIncludedColumnTestService, IIncludedColumnTestService
	{
		public IncludedColumnTestService(
			ILogger<IIncludedColumnTestRepository> logger,
			IMediator mediator,
			IIncludedColumnTestRepository includedColumnTestRepository,
			IApiIncludedColumnTestServerRequestModelValidator includedColumnTestModelValidator,
			IDALIncludedColumnTestMapper dalIncludedColumnTestMapper)
			: base(logger,
			       mediator,
			       includedColumnTestRepository,
			       includedColumnTestModelValidator,
			       dalIncludedColumnTestMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>59b5ccb47a25f9862225c6348b51d7f6</Hash>
</Codenesium>*/