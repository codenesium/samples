using MediatR;
using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class CompositePrimaryKeyService : AbstractCompositePrimaryKeyService, ICompositePrimaryKeyService
	{
		public CompositePrimaryKeyService(
			ILogger<ICompositePrimaryKeyRepository> logger,
			IMediator mediator,
			ICompositePrimaryKeyRepository compositePrimaryKeyRepository,
			IApiCompositePrimaryKeyServerRequestModelValidator compositePrimaryKeyModelValidator,
			IBOLCompositePrimaryKeyMapper bolCompositePrimaryKeyMapper,
			IDALCompositePrimaryKeyMapper dalCompositePrimaryKeyMapper)
			: base(logger,
			       mediator,
			       compositePrimaryKeyRepository,
			       compositePrimaryKeyModelValidator,
			       bolCompositePrimaryKeyMapper,
			       dalCompositePrimaryKeyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>068d6948642831e44b14f3105c9d3953</Hash>
</Codenesium>*/