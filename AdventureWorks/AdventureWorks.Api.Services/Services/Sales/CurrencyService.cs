using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class CurrencyService : AbstractCurrencyService, ICurrencyService
	{
		public CurrencyService(
			ILogger<ICurrencyRepository> logger,
			ICurrencyRepository currencyRepository,
			IApiCurrencyServerRequestModelValidator currencyModelValidator,
			IBOLCurrencyMapper bolCurrencyMapper,
			IDALCurrencyMapper dalCurrencyMapper,
			IBOLCurrencyRateMapper bolCurrencyRateMapper,
			IDALCurrencyRateMapper dalCurrencyRateMapper)
			: base(logger,
			       currencyRepository,
			       currencyModelValidator,
			       bolCurrencyMapper,
			       dalCurrencyMapper,
			       bolCurrencyRateMapper,
			       dalCurrencyRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>657cbb29fa41207dc9b16e3a945c05a0</Hash>
</Codenesium>*/