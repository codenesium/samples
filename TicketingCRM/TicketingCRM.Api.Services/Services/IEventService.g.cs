using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IEventService
	{
		Task<CreateResponse<ApiEventServerResponseModel>> Create(
			ApiEventServerRequestModel model);

		Task<UpdateResponse<ApiEventServerResponseModel>> Update(int id,
		                                                          ApiEventServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventServerResponseModel> Get(int id);

		Task<List<ApiEventServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventServerResponseModel>> ByCityId(int cityId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>30a5c92622ebc5984e70f693bf481334</Hash>
</Codenesium>*/