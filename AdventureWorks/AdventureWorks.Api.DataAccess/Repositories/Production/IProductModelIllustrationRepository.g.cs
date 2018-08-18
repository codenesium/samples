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
    <Hash>8a4e3e78481c62378f14d0a036f7b9fd</Hash>
</Codenesium>*/