using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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

		Task<List<ApiEventStudentResponseModel>> EventStudentsByEventId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventTeacherResponseModel>> EventTeachersByEventId(int eventId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e87fa28b45b5ff8273bf84a25a5b6ef8</Hash>
</Codenesium>*/