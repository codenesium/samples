using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiProductCostHistoryModelMapper
	{
		ApiProductCostHistoryResponseModel MapRequestToResponse(
			int productID,
			ApiProductCostHistoryRequestModel request);

		ApiProductCostHistoryRequestModel MapResponseToRequest(
			ApiProductCostHistoryResponseModel response);

		JsonPatchDocument<ApiProductCostHistoryRequestModel> CreatePatch(ApiProductCostHistoryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d74af7b768108206de312448b4af334a</Hash>
</Codenesium>*/