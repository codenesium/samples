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
    <Hash>c73b91e64a413f938f83bd8079dc3626</Hash>
</Codenesium>*/