using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class SaleService : AbstractSaleService, ISaleService
	{
		public SaleService(
			ILogger<ISaleRepository> logger,
			ISaleRepository saleRepository,
			IApiSaleServerRequestModelValidator saleModelValidator,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper)
			: base(logger,
			       saleRepository,
			       saleModelValidator,
			       bolSaleMapper,
			       dalSaleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4462838807b3695a10a146e0b21a1a6f</Hash>
</Codenesium>*/