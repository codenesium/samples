using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IEventTeacherService
	{
		Task<CreateResponse<ApiEventTeacherServerResponseModel>> Create(
			ApiEventTeacherServerRequestModel model);

		Task<UpdateResponse<ApiEventTeacherServerResponseModel>> Update(int id,
		                                                                 ApiEventTeacherServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventTeacherServerResponseModel> Get(int id);

		Task<List<ApiEventTeacherServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiEventTeacherServerResponseModel>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventTeacherServerResponseModel>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a7ca18de111652d718f78a2ae0f3bd8e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/