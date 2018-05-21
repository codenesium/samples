using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelIllustrationRepository
	{
		Task<POCOProductModelIllustration> Create(ApiProductModelIllustrationModel model);

		Task Update(int productModelID,
		            ApiProductModelIllustrationModel model);

		Task Delete(int productModelID);

		Task<POCOProductModelIllustration> Get(int productModelID);

		Task<List<POCOProductModelIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3d7025dc513321c8b252a0cb65b3148e</Hash>
</Codenesium>*/