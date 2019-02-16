using MediatR;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
    <Hash>edd835edbfa0a65caa940262f2a48bc2</Hash>
</Codenesium>*/