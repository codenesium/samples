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

		Task<List<ProductDescription>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ProductModelProductDescriptionCulture>> ProductModelProductDescriptionCulturesByProductDescriptionID(int productDescriptionID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>43e34553e09b261e6ceea2edbee1ea2c</Hash>
</Codenesium>*/