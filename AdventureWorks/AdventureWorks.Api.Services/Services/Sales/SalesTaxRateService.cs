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
			IBOLSalesTaxRateMapper bolSalesTaxRateMapper,
			IDALSalesTaxRateMapper dalSalesTaxRateMapper)
			: base(logger,
			       mediator,
			       salesTaxRateRepository,
			       salesTaxRateModelValidator,
			       bolSalesTaxRateMapper,
			       dalSalesTaxRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>72620f69be809579f60b6f1571d38482</Hash>
</Codenesium>*/