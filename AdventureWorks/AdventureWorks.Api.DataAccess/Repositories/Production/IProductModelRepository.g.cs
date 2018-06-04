using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelRepository
	{
		Task<ProductModel> Create(ProductModel item);

		Task Update(ProductModel item);

		Task Delete(int productModelID);

		Task<ProductModel> Get(int productModelID);

		Task<List<ProductModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ProductModel> GetName(string name);
		Task<List<ProductModel>> GetCatalogDescription(string catalogDescription);
		Task<List<ProductModel>> GetInstructions(string instructions);
	}
}

/*<Codenesium>
    <Hash>1365962ca5324a2ae189aced42c6cc5e</Hash>
</Codenesium>*/