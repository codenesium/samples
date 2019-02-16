using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
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
    <Hash>440efe5fed50709ceeb498df3b0aaf5f</Hash>
</Codenesium>*/