using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IEventService
	{
		Task<CreateResponse<ApiEventServerResponseModel>> Create(
			ApiEventServerRequestModel model);

		Task<UpdateResponse<ApiEventServerResponseModel>> Update(int id,
		                                                          ApiEventServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventServerResponseModel> Get(int id);

		Task<List<ApiEventServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiEventStudentServerResponseModel>> EventStudentsByEventId(int eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventTeacherServerResponseModel>> EventTeachersByEventId(int eventId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ac77a2522b2f01295f5fa36981734463</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/