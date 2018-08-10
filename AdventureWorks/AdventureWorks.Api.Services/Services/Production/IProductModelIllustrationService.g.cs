using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductModelIllustrationService
	{
		Task<CreateResponse<ApiProductModelIllustrationResponseModel>> Create(
			ApiProductModelIllustrationRequestModel model);

		Task<UpdateResponse<ApiProductModelIllustrationResponseModel>> Update(int productModelID,
		                                                                       ApiProductModelIllustrationRequestModel model);

		Task<ActionResponse> Delete(int productModelID);

		Task<ApiProductModelIllustrationResponseModel> Get(int productModelID);

		Task<List<ApiProductModelIllustrationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d06b7d2673e53c02f2990428c4f4dd0a</Hash>
</Codenesium>*/