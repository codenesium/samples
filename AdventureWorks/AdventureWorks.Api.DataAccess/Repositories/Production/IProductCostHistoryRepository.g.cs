using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductCostHistoryRepository
	{
		Task<ProductCostHistory> Create(ProductCostHistory item);

		Task Update(ProductCostHistory item);

		Task Delete(int productID);

		Task<ProductCostHistory> Get(int productID);

		Task<List<ProductCostHistory>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2c6679c8a1ea82004276bcbbd8e3d869</Hash>
</Codenesium>*/