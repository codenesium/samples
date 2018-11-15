using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class CurrencyRateService : AbstractCurrencyRateService, ICurrencyRateService
	{
		public CurrencyRateService(
			ILogger<ICurrencyRateRepository> logger,
			ICurrencyRateRepository currencyRateRepository,
			IApiCurrencyRateServerRequestModelValidator currencyRateModelValidator,
			IBOLCurrencyRateMapper bolCurrencyRateMapper,
			IDALCurrencyRateMapper dalCurrencyRateMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base(logger,
			       currencyRateRepository,
			       currencyRateModelValidator,
			       bolCurrencyRateMapper,
			       dalCurrencyRateMapper,
			       bolSalesOrderHeaderMapper,
			       dalSalesOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5e2b670c96283b37207c4b96a7efb4af</Hash>
</Codenesium>*/