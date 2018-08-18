using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCurrencyRateMapper
	{
		CurrencyRate MapBOToEF(
			BOCurrencyRate bo);

		BOCurrencyRate MapEFToBO(
			CurrencyRate efCurrencyRate);

		List<BOCurrencyRate> MapEFToBO(
			List<CurrencyRate> records);
	}
}

/*<Codenesium>
    <Hash>a03befd7ebdf2296e6b4ed0063611973</Hash>
</Codenesium>*/