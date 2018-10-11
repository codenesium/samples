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
	public partial class CurrencyRateService : AbstractCurrencyRateService, ICurrencyRateService
	{
		public CurrencyRateService(
			ILogger<ICurrencyRateRepository> logger,
			ICurrencyRateRepository currencyRateRepository,
			IApiCurrencyRateRequestModelValidator currencyRateModelValidator,
			IBOLCurrencyRateMapper bolcurrencyRateMapper,
			IDALCurrencyRateMapper dalcurrencyRateMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base(logger,
			       currencyRateRepository,
			       currencyRateModelValidator,
			       bolcurrencyRateMapper,
			       dalcurrencyRateMapper,
			       bolSalesOrderHeaderMapper,
			       dalSalesOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1a89804e1e4c953ecab28a2f92e4af7d</Hash>
</Codenesium>*/