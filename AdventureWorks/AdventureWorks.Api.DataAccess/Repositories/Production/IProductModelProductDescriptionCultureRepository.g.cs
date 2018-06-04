using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelProductDescriptionCultureRepository
	{
		Task<ProductModelProductDescriptionCulture> Create(ProductModelProductDescriptionCulture item);

		Task Update(ProductModelProductDescriptionCulture item);

		Task Delete(int productModelID);

		Task<ProductModelProductDescriptionCulture> Get(int productModelID);

		Task<List<ProductModelProductDescriptionCulture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0d7aafe4326b8c8d3231732a81bb4674</Hash>
</Codenesium>*/