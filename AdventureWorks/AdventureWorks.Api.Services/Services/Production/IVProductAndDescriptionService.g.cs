using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IVProductAndDescriptionService
	{
		Task<CreateResponse<ApiVProductAndDescriptionResponseModel>> Create(
			ApiVProductAndDescriptionRequestModel model);

		Task<UpdateResponse<ApiVProductAndDescriptionResponseModel>> Update(string cultureID,
		                                                                     ApiVProductAndDescriptionRequestModel model);

		Task<ActionResponse> Delete(string cultureID);

		Task<ApiVProductAndDescriptionResponseModel> Get(string cultureID);

		Task<List<ApiVProductAndDescriptionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiVProductAndDescriptionResponseModel> ByCultureIDProductID(string cultureID, int productID);
	}
}

/*<Codenesium>
    <Hash>4ce60c79679961a0f97f6df3030655c8</Hash>
</Codenesium>*/