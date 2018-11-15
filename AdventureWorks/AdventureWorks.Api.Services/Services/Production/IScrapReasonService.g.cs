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

		Task<List<ApiScrapReasonServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiScrapReasonServerResponseModel> ByName(string name);

		Task<List<ApiWorkOrderServerResponseModel>> WorkOrdersByScrapReasonID(short scrapReasonID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7346c4976645d3e9655d5bf02f2bff14</Hash>
</Codenesium>*/