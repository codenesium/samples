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
			IDALSpeciesMapper dalSpeciesMapper)
			: base(logger,
			       mediator,
			       speciesRepository,
			       speciesModelValidator,
			       dalSpeciesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3d1408eda8296d7d9f298e51e5a07795</Hash>
</Codenesium>*/