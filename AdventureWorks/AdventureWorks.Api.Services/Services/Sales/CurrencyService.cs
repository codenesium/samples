using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class CurrencyService : AbstractCurrencyService, ICurrencyService
	{
		public CurrencyService(
			ILogger<ICurrencyRepository> logger,
			ICurrencyRepository currencyRepository,
			IApiCurrencyRequestModelValidator currencyModelValidator,
			IBOLCurrencyMapper bolcurrencyMapper,
			IDALCurrencyMapper dalcurrencyMapper,
			IBOLCurrencyRateMapper bolCurrencyRateMapper,
			IDALCurrencyRateMapper dalCurrencyRateMapper)
			: base(logger,
			       currencyRepository,
			       currencyModelValidator,
			       bolcurrencyMapper,
			       dalcurrencyMapper,
			       bolCurrencyRateMapper,
			       dalCurrencyRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d4ff526fb4ea4999c09a29c31b9b357e</Hash>
</Codenesium>*/