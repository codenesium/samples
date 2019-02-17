using MediatR;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
    <Hash>86b31d4852764de7792d220b40b5b4fa</Hash>
</Codenesium>*/