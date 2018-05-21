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
		Task<CreateResponse<POCOProductModelIllustration>> Create(
			ApiProductModelIllustrationModel model);

		Task<ActionResponse> Update(int productModelID,
		                            ApiProductModelIllustrationModel model);

		Task<ActionResponse> Delete(int productModelID);

		Task<POCOProductModelIllustration> Get(int productModelID);

		Task<List<POCOProductModelIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7c88189629d90bb6e4792d04abd22c76</Hash>
</Codenesium>*/