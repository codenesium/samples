using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelIllustrationRepository
	{
		Task<ProductModelIllustration> Create(ProductModelIllustration item);

		Task Update(ProductModelIllustration item);

		Task Delete(int productModelID);

		Task<ProductModelIllustration> Get(int productModelID);

		Task<List<ProductModelIllustration>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3de003db979d678f07d444e1d5f265f3</Hash>
</Codenesium>*/