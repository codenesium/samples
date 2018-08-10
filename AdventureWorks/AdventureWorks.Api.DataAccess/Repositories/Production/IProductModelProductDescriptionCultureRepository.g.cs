using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductModelProductDescriptionCultureRepository
	{
		Task<ProductModelProductDescriptionCulture> Create(ProductModelProductDescriptionCulture item);

		Task Update(ProductModelProductDescriptionCulture item);

		Task Delete(int productModelID);

		Task<ProductModelProductDescriptionCulture> Get(int productModelID);

		Task<List<ProductModelProductDescriptionCulture>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>73cba2274e5a5536246742e7c58a76c8</Hash>
</Codenesium>*/