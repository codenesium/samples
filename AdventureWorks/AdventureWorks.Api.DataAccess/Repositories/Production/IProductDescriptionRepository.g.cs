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

		Task<ProductDescription> ByRowguid(Guid rowguid);
	}
}

/*<Codenesium>
    <Hash>d956f9dc4a21b569b483dc59ef7f1e90</Hash>
</Codenesium>*/