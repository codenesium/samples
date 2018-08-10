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
    <Hash>a2f2a49f933e45d2ff8cc71b33457fd9</Hash>
</Codenesium>*/