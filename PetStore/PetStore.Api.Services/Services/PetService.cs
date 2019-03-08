using MediatR;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public partial class PetService : AbstractPetService, IPetService
	{
		public PetService(
			ILogger<IPetRepository> logger,
			IMediator mediator,
			IPetRepository petRepository,
			IApiPetServerRequestModelValidator petModelValidator,
			IDALPetMapper dalPetMapper,
			IDALSaleMapper dalSaleMapper)
			: base(logger,
			       mediator,
			       petRepository,
			       petModelValidator,
			       dalPetMapper,
			       dalSaleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>edd79ea7dee08f1adf253835c0b6c1f5</Hash>
</Codenesium>*/