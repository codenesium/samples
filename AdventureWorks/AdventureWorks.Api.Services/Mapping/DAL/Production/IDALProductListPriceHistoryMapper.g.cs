using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>9d6e6b6d0f45cc5adf4a41530c94bd3d</Hash>
</Codenesium>*/