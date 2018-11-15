using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PetService : AbstractPetService, IPetService
	{
		public PetService(
			ILogger<IPetRepository> logger,
			IPetRepository petRepository,
			IApiPetServerRequestModelValidator petModelValidator,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper)
			: base(logger,
			       petRepository,
			       petModelValidator,
			       bolPetMapper,
			       dalPetMapper,
			       bolSaleMapper,
			       dalSaleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f2b62fa4a5a5382788645b35809bdb25</Hash>
</Codenesium>*/