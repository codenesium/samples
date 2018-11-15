using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class SpeciesService : AbstractSpeciesService, ISpeciesService
	{
		public SpeciesService(
			ILogger<ISpeciesRepository> logger,
			ISpeciesRepository speciesRepository,
			IApiSpeciesServerRequestModelValidator speciesModelValidator,
			IBOLSpeciesMapper bolSpeciesMapper,
			IDALSpeciesMapper dalSpeciesMapper,
			IBOLBreedMapper bolBreedMapper,
			IDALBreedMapper dalBreedMapper)
			: base(logger,
			       speciesRepository,
			       speciesModelValidator,
			       bolSpeciesMapper,
			       dalSpeciesMapper,
			       bolBreedMapper,
			       dalBreedMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9c12eafbcd55163aac0182c917757bae</Hash>
</Codenesium>*/