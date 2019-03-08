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
			IDALPenMapper dalPenMapper,
			IDALPetMapper dalPetMapper)
			: base(logger,
			       mediator,
			       penRepository,
			       penModelValidator,
			       dalPenMapper,
			       dalPetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9840752ffbaa3380027c485460601051</Hash>
</Codenesium>*/