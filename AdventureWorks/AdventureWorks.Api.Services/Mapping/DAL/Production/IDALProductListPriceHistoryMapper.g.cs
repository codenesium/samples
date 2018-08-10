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
    <Hash>3fbc3fd0489ea9e41a45acf1a197f5a4</Hash>
</Codenesium>*/