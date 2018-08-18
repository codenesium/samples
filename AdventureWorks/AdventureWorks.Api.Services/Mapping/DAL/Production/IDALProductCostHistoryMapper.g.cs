using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductCostHistoryMapper
	{
		ProductCostHistory MapBOToEF(
			BOProductCostHistory bo);

		BOProductCostHistory MapEFToBO(
			ProductCostHistory efProductCostHistory);

		List<BOProductCostHistory> MapEFToBO(
			List<ProductCostHistory> records);
	}
}

/*<Codenesium>
    <Hash>56ae2ded719a301c47687d1fd5ced69d</Hash>
</Codenesium>*/