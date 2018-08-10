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

		Task<List<ProductProductPhoto>> ProductProductPhotoes(int productPhotoID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4007ff83203a125acfcc965e97f2c403</Hash>
</Codenesium>*/