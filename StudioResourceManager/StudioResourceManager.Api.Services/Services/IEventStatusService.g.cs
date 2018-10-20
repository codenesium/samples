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

		Task<List<ApiEventResponseModel>> EventsByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2ff1466ceec78017f93cc3d58ecbcd28</Hash>
</Codenesium>*/