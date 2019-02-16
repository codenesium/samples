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
			IDALSpeciesMapper dalSpeciesMapper,
			IDALBreedMapper dalBreedMapper)
			: base(logger,
			       mediator,
			       speciesRepository,
			       speciesModelValidator,
			       dalSpeciesMapper,
			       dalBreedMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a463f51d2e1d4a274474a5d0f1dad0b1</Hash>
</Codenesium>*/