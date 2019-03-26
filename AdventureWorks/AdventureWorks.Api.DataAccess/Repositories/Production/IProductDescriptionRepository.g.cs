using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductDescriptionRepository
	{
		Task<ProductDescription> Create(ProductDescription item);

		Task Update(ProductDescription item);

		Task Delete(int productDescriptionID);

		Task<ProductDescription> Get(int productDescriptionID);

		Task<List<ProductDescription>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ProductDescription> ByRowguid(Guid rowguid);
	}
}

/*<Codenesium>
    <Hash>5c8df305e4eb0357ac7e333d1ec8e5c4</Hash>
</Codenesium>*/