using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class CurrencyService : AbstractCurrencyService, ICurrencyService
	{
		public CurrencyService(
			ILogger<ICurrencyRepository> logger,
			IMediator mediator,
			ICurrencyRepository currencyRepository,
			IApiCurrencyServerRequestModelValidator currencyModelValidator,
			IDALCurrencyMapper dalCurrencyMapper,
			IDALCurrencyRateMapper dalCurrencyRateMapper)
			: base(logger,
			       mediator,
			       currencyRepository,
			       currencyModelValidator,
			       dalCurrencyMapper,
			       dalCurrencyRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>371de1e6a634c88b445f966dcee2fec5</Hash>
</Codenesium>*/