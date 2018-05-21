using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCostHistoryRepository
	{
		Task<POCOProductCostHistory> Create(ApiProductCostHistoryModel model);

		Task Update(int productID,
		            ApiProductCostHistoryModel model);

		Task Delete(int productID);

		Task<POCOProductCostHistory> Get(int productID);

		Task<List<POCOProductCostHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9a11b72a16adeeba541c7f29d533f2f7</Hash>
</Codenesium>*/