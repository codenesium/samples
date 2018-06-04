using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>9def470d4cfba4838b5033d15ebfe168</Hash>
</Codenesium>*/