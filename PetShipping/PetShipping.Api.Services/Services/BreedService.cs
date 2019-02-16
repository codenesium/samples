using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class BreedService : AbstractBreedService, IBreedService
	{
		public BreedService(
			ILogger<IBreedRepository> logger,
			IMediator mediator,
			IBreedRepository breedRepository,
			IApiBreedServerRequestModelValidator breedModelValidator,
			IDALBreedMapper dalBreedMapper,
			IDALPetMapper dalPetMapper)
			: base(logger,
			       mediator,
			       breedRepository,
			       breedModelValidator,
			       dalBreedMapper,
			       dalPetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3eca25c279554d28d703e70fbebfedde</Hash>
</Codenesium>*/