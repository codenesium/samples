using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IVEventService
	{
		Task<CreateResponse<ApiVEventResponseModel>> Create(
			ApiVEventRequestModel model);

		Task<UpdateResponse<ApiVEventResponseModel>> Update(int id,
		                                                     ApiVEventRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVEventResponseModel> Get(int id);

		Task<List<ApiVEventResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7ba675eeb66ebbaffaee201a916f19d9</Hash>
</Codenesium>*/