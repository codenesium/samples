using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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

		Task<List<ApiEventServerResponseModel>> ByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventServerResponseModel>> ByStudentId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventServerResponseModel>> ByTeacherId(int eventId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>543fa6db373d57ddc93675e9bde34659</Hash>
</Codenesium>*/