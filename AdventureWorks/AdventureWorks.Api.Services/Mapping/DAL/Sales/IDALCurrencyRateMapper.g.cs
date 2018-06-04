using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>b79168f091a5678eb04436a83ea9565a</Hash>
</Codenesium>*/