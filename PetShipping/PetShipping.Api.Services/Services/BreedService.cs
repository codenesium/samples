using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class BreedService : AbstractBreedService, IBreedService
	{
		public BreedService(
			ILogger<IBreedRepository> logger,
			IBreedRepository breedRepository,
			IApiBreedServerRequestModelValidator breedModelValidator,
			IBOLBreedMapper bolBreedMapper,
			IDALBreedMapper dalBreedMapper,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper)
			: base(logger,
			       breedRepository,
			       breedModelValidator,
			       bolBreedMapper,
			       dalBreedMapper,
			       bolPetMapper,
			       dalPetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>562d67a4ab0ba922132231f9f2a78075</Hash>
</Codenesium>*/