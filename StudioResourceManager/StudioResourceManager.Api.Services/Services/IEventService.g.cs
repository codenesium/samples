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

		Task<List<ApiEventStudentResponseModel>> EventStudents(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventTeacherResponseModel>> EventTeachers(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventResponseModel>> ByStudentId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventResponseModel>> ByTeacherId(int eventId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f8c506212a8bd2f523a00b9ecbd6bae9</Hash>
</Codenesium>*/