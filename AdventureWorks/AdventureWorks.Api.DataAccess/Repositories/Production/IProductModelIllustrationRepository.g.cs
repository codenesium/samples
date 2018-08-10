using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductModelIllustrationRepository
	{
		Task<ProductModelIllustration> Create(ProductModelIllustration item);

		Task Update(ProductModelIllustration item);

		Task Delete(int productModelID);

		Task<ProductModelIllustration> Get(int productModelID);

		Task<List<ProductModelIllustration>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6833de1eb1931bb329baa8ae4457b71e</Hash>
</Codenesium>*/