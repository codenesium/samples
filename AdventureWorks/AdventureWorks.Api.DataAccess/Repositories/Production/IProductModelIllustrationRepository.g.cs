using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelIllustrationRepository
	{
		Task<ProductModelIllustration> Create(ProductModelIllustration item);

		Task Update(ProductModelIllustration item);

		Task Delete(int productModelID);

		Task<ProductModelIllustration> Get(int productModelID);

		Task<List<ProductModelIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>04a75665abef476faa200760a2345edf</Hash>
</Codenesium>*/