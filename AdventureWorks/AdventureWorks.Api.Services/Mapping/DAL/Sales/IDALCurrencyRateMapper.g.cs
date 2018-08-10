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
    <Hash>c19a01f11b68e4470980542d408d381f</Hash>
</Codenesium>*/