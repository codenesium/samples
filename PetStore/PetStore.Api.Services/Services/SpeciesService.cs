using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public partial class SpeciesService : AbstractSpeciesService, ISpeciesService
	{
		public SpeciesService(
			ILogger<ISpeciesRepository> logger,
			ISpeciesRepository speciesRepository,
			IApiSpeciesServerRequestModelValidator speciesModelValidator,
			IBOLSpeciesMapper bolSpeciesMapper,
			IDALSpeciesMapper dalSpeciesMapper,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper)
			: base(logger,
			       speciesRepository,
			       speciesModelValidator,
			       bolSpeciesMapper,
			       dalSpeciesMapper,
			       bolPetMapper,
			       dalPetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7a283bdb5db7bde673310228bde1d0a4</Hash>
</Codenesium>*/