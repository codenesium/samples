using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductProductPhotoRepository
	{
		Task<ProductProductPhoto> Create(ProductProductPhoto item);

		Task Update(ProductProductPhoto item);

		Task Delete(int productID);

		Task<ProductProductPhoto> Get(int productID);

		Task<List<ProductProductPhoto>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>fb682ea105c502e05ecd6dc62c0dc410</Hash>
</Codenesium>*/