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

		Task<List<ProductProductPhoto>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Product> ProductByProductID(int productID);

		Task<ProductPhoto> ProductPhotoByProductPhotoID(int productPhotoID);
	}
}

/*<Codenesium>
    <Hash>6bd8e00c20d266cedd5706ed96300b8f</Hash>
</Codenesium>*/