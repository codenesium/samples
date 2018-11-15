using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class SalesTaxRateService : AbstractSalesTaxRateService, ISalesTaxRateService
	{
		public SalesTaxRateService(
			ILogger<ISalesTaxRateRepository> logger,
			ISalesTaxRateRepository salesTaxRateRepository,
			IApiSalesTaxRateServerRequestModelValidator salesTaxRateModelValidator,
			IBOLSalesTaxRateMapper bolSalesTaxRateMapper,
			IDALSalesTaxRateMapper dalSalesTaxRateMapper)
			: base(logger,
			       salesTaxRateRepository,
			       salesTaxRateModelValidator,
			       bolSalesTaxRateMapper,
			       dalSalesTaxRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>12d515a531db27ccdb186d6f31a6951f</Hash>
</Codenesium>*/