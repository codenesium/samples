using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductCostHistoryMapper
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
    <Hash>4a85d602f878503cbdb8784d6b442446</Hash>
</Codenesium>*/