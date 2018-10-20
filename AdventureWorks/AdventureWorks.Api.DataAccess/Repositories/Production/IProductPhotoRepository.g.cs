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

		Task<List<ProductPhoto>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ProductProductPhoto>> ProductProductPhotoesByProductPhotoID(int productPhotoID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1fbe301c386eee6db11da200594f6677</Hash>
</Codenesium>*/