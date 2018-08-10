using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IEventService
	{
		Task<CreateResponse<ApiEventResponseModel>> Create(
			ApiEventRequestModel model);

		Task<UpdateResponse<ApiEventResponseModel>> Update(int id,
		                                                    ApiEventRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventResponseModel> Get(int id);

		Task<List<ApiEventResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventResponseModel>> ByCityId(int cityId);
	}
}

/*<Codenesium>
    <Hash>1549881451fae9986880a7181519e919</Hash>
</Codenesium>*/