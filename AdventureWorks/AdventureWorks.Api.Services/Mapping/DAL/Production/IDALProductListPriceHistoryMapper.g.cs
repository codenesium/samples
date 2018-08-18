using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductListPriceHistoryMapper
	{
		ProductListPriceHistory MapBOToEF(
			BOProductListPriceHistory bo);

		BOProductListPriceHistory MapEFToBO(
			ProductListPriceHistory efProductListPriceHistory);

		List<BOProductListPriceHistory> MapEFToBO(
			List<ProductListPriceHistory> records);
	}
}

/*<Codenesium>
    <Hash>1bd873db8bf03b70f08826f73161aacc</Hash>
</Codenesium>*/