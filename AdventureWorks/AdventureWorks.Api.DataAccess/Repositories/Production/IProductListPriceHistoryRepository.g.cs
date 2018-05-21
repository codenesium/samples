using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductListPriceHistoryRepository
	{
		Task<POCOProductListPriceHistory> Create(ApiProductListPriceHistoryModel model);

		Task Update(int productID,
		            ApiProductListPriceHistoryModel model);

		Task Delete(int productID);

		Task<POCOProductListPriceHistory> Get(int productID);

		Task<List<POCOProductListPriceHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>de006e2870b6623c8492ec77b05f6b85</Hash>
</Codenesium>*/