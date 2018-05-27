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
		Task<CreateResponse<ApiProductModelIllustrationResponseModel>> Create(
			ApiProductModelIllustrationRequestModel model);

		Task<ActionResponse> Update(int productModelID,
		                            ApiProductModelIllustrationRequestModel model);

		Task<ActionResponse> Delete(int productModelID);

		Task<ApiProductModelIllustrationResponseModel> Get(int productModelID);

		Task<List<ApiProductModelIllustrationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>956fe4e9f8a3e6432f01a14d495a2c9f</Hash>
</Codenesium>*/