using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class CurrencyService: AbstractCurrencyService, ICurrencyService
	{
		public CurrencyService(
			ILogger<CurrencyRepository> logger,
			ICurrencyRepository currencyRepository,
			IApiCurrencyRequestModelValidator currencyModelValidator,
			IBOLCurrencyMapper BOLcurrencyMapper,
			IDALCurrencyMapper DALcurrencyMapper)
			: base(logger, currencyRepository,
			       currencyModelValidator,
			       BOLcurrencyMapper,
			       DALcurrencyMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>aa193a615b36a16bf6ee5dbfcd3305fb</Hash>
</Codenesium>*/