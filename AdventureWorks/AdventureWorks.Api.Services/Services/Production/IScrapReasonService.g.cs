using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IScrapReasonService
	{
		Task<CreateResponse<ApiScrapReasonServerResponseModel>> Create(
			ApiScrapReasonServerRequestModel model);

		Task<UpdateResponse<ApiScrapReasonServerResponseModel>> Update(short scrapReasonID,
		                                                                ApiScrapReasonServerRequestModel model);

		Task<ActionResponse> Delete(short scrapReasonID);

		Task<ApiScrapReasonServerResponseModel> Get(short scrapReasonID);

		Task<List<ApiScrapReasonServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiScrapReasonServerResponseModel> ByName(string name);

		Task<List<ApiWorkOrderServerResponseModel>> WorkOrdersByScrapReasonID(short scrapReasonID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c97041796438d9ff97d1b8e8a0b05e8b</Hash>
</Codenesium>*/