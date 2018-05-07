using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductModelIllustration
	{
		Task<CreateResponse<int>> Create(
			ProductModelIllustrationModel model);

		Task<ActionResponse> Update(int productModelID,
		                            ProductModelIllustrationModel model);

		Task<ActionResponse> Delete(int productModelID);

		POCOProductModelIllustration Get(int productModelID);

		List<POCOProductModelIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>65a28921fbff1f0cae273ae3f33bccbd</Hash>
</Codenesium>*/