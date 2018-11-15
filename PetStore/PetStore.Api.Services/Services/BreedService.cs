using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
    <Hash>dd38d2f8c8679eee6034315b69c10f70</Hash>
</Codenesium>*/