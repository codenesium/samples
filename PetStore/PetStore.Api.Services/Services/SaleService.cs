using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
    <Hash>390d8bdf2e63bad198f8367968cc268c</Hash>
</Codenesium>*/