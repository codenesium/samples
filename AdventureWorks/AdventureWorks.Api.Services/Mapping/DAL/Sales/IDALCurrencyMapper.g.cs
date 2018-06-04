using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALCurrencyMapper
	{
		Currency MapBOToEF(
			BOCurrency bo);

		BOCurrency MapEFToBO(
			Currency efCurrency);

		List<BOCurrency> MapEFToBO(
			List<Currency> records);
	}
}

/*<Codenesium>
    <Hash>91fad624a2ae984a7563e3816f54f93f</Hash>
</Codenesium>*/