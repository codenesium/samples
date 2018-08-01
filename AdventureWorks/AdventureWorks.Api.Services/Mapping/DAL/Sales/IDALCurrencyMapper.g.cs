using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>4f16898af138a49cd05c33fae0ea6370</Hash>
</Codenesium>*/