using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class SpeciesService : AbstractSpeciesService, ISpeciesService
	{
		public SpeciesService(
			ILogger<ISpeciesRepository> logger,
			IMediator mediator,
			ISpeciesRepository speciesRepository,
			IApiSpeciesServerRequestModelValidator speciesModelValidator,
			IBOLSpeciesMapper bolSpeciesMapper,
			IDALSpeciesMapper dalSpeciesMapper,
			IBOLBreedMapper bolBreedMapper,
			IDALBreedMapper dalBreedMapper)
			: base(logger,
			       mediator,
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
    <Hash>e3f24d507ed58606ac95a9cff4457bbf</Hash>
</Codenesium>*/