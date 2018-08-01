using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALCurrencyRateMapper
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
    <Hash>82e7ab35858c9ab175ed979d9150e683</Hash>
</Codenesium>*/