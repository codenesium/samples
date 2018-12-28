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
			IBOLIncludedColumnTestMapper bolIncludedColumnTestMapper,
			IDALIncludedColumnTestMapper dalIncludedColumnTestMapper)
			: base(logger,
			       mediator,
			       includedColumnTestRepository,
			       includedColumnTestModelValidator,
			       bolIncludedColumnTestMapper,
			       dalIncludedColumnTestMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>158dec9a1e95ea170df6359fe88960a5</Hash>
</Codenesium>*/