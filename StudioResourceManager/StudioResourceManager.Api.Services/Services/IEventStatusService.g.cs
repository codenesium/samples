using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IEventStatusService
	{
		Task<CreateResponse<ApiEventStatusResponseModel>> Create(
			ApiEventStatusRequestModel model);

		Task<UpdateResponse<ApiEventStatusResponseModel>> Update(int id,
		                                                          ApiEventStatusRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventStatusResponseModel> Get(int id);

		Task<List<ApiEventStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d1a1e7a60f5e30722a7f432a1a9492ad</Hash>
</Codenesium>*/