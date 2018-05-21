using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductRepository
	{
		Task<POCOProduct> Create(ApiProductModel model);

		Task Update(int productID,
		            ApiProductModel model);

		Task Delete(int productID);

		Task<POCOProduct> Get(int productID);

		Task<List<POCOProduct>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOProduct> GetName(string name);
		Task<POCOProduct> GetProductNumber(string productNumber);
	}
}

/*<Codenesium>
    <Hash>73dee50b3102f0a197ad7e08a1f0f87e</Hash>
</Codenesium>*/