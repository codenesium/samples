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
			IBOLPenMapper bolPenMapper,
			IDALPenMapper dalPenMapper,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper)
			: base(logger,
			       mediator,
			       penRepository,
			       penModelValidator,
			       bolPenMapper,
			       dalPenMapper,
			       bolPetMapper,
			       dalPetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f1d347cfba290ec0a8efa3c78abdf75b</Hash>
</Codenesium>*/