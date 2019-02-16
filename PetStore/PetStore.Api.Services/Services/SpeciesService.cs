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
			IDALPetMapper dalPetMapper)
			: base(logger,
			       mediator,
			       speciesRepository,
			       speciesModelValidator,
			       dalSpeciesMapper,
			       dalPetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bfab7f2fbf11a3742c984b4cdf371631</Hash>
</Codenesium>*/