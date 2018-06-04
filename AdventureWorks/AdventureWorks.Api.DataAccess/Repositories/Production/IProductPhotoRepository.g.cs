using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductPhotoRepository
	{
		Task<ProductPhoto> Create(ProductPhoto item);

		Task Update(ProductPhoto item);

		Task Delete(int productPhotoID);

		Task<ProductPhoto> Get(int productPhotoID);

		Task<List<ProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cfba7ef6e46e3c7ec05a3d94e3ad2ca3</Hash>
</Codenesium>*/