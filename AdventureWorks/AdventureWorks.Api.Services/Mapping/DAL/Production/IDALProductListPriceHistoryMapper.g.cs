using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductListPriceHistoryMapper
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
    <Hash>cd62864a92292ee9d277a5f2884b8f26</Hash>
</Codenesium>*/