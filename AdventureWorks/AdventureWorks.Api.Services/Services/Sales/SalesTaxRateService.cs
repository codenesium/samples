using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class SalesTaxRateService : AbstractSalesTaxRateService, ISalesTaxRateService
	{
		public SalesTaxRateService(
			ILogger<ISalesTaxRateRepository> logger,
			IMediator mediator,
			ISalesTaxRateRepository salesTaxRateRepository,
			IApiSalesTaxRateServerRequestModelValidator salesTaxRateModelValidator,
			IDALSalesTaxRateMapper dalSalesTaxRateMapper)
			: base(logger,
			       mediator,
			       salesTaxRateRepository,
			       salesTaxRateModelValidator,
			       dalSalesTaxRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>afc4ae945c7cb0efdc9f868419f53205</Hash>
</Codenesium>*/