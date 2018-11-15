using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
    <Hash>17b16551b3de391df3522e4464c8ed33</Hash>
</Codenesium>*/