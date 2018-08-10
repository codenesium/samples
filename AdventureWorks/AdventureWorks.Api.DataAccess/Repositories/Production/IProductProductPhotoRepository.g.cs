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
    <Hash>56e5254295e12e4e68172b27900d11b6</Hash>
</Codenesium>*/