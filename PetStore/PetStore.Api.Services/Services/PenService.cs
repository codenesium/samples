using MediatR;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public partial class PenService : AbstractPenService, IPenService
	{
		public PenService(
			ILogger<IPenRepository> logger,
			IMediator mediator,
			IPenRepository penRepository,
			IApiPenServerRequestModelValidator penModelValidator,
			IDALPenMapper dalPenMapper)
			: base(logger,
			       mediator,
			       penRepository,
			       penModelValidator,
			       dalPenMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4c43108c1cf665067314a07f245fb8e0</Hash>
</Codenesium>*/