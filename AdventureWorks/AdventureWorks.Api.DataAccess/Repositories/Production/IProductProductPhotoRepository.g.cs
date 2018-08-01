using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductProductPhotoRepository
	{
		Task<ProductProductPhoto> Create(ProductProductPhoto item);

		Task Update(ProductProductPhoto item);

		Task Delete(int productID);

		Task<ProductProductPhoto> Get(int productID);

		Task<List<ProductProductPhoto>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9301453c69a50f14a642a652c671ccc8</Hash>
</Codenesium>*/