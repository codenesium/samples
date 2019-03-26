using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductPhotoRepository
	{
		Task<ProductPhoto> Create(ProductPhoto item);

		Task Update(ProductPhoto item);

		Task Delete(int productPhotoID);

		Task<ProductPhoto> Get(int productPhotoID);

		Task<List<ProductPhoto>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ProductProductPhoto>> ProductProductPhotoesByProductPhotoID(int productPhotoID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e23f2cdb842a4ffa9c46e47498d93f32</Hash>
</Codenesium>*/