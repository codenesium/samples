using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCurrencyMapper
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
    <Hash>3be40e28f03fce2f4cebc687333a3004</Hash>
</Codenesium>*/