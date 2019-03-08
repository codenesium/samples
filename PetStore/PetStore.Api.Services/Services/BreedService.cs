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
			IDALBreedMapper dalBreedMapper)
			: base(logger,
			       mediator,
			       breedRepository,
			       breedModelValidator,
			       dalBreedMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>150660b44a63330658034689e3b18f09</Hash>
</Codenesium>*/