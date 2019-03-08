using MediatR;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public partial class PetService : AbstractPetService, IPetService
	{
		public PetService(
			ILogger<IPetRepository> logger,
			IMediator mediator,
			IPetRepository petRepository,
			IApiPetServerRequestModelValidator petModelValidator,
			IDALPetMapper dalPetMapper)
			: base(logger,
			       mediator,
			       petRepository,
			       petModelValidator,
			       dalPetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>959490f755d955b85fcb2e63ef29051c</Hash>
</Codenesium>*/