using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductProductPhotoRepository
	{
		Task<ProductProductPhoto> Create(ProductProductPhoto item);

		Task Update(ProductProductPhoto item);

		Task Delete(int productID);

		Task<ProductProductPhoto> Get(int productID);

		Task<List<ProductProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1dfb94c34195aef12d8ca8069756b043</Hash>
</Codenesium>*/