using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IEventTeacherService
	{
		Task<CreateResponse<ApiEventTeacherServerResponseModel>> Create(
			ApiEventTeacherServerRequestModel model);

		Task<UpdateResponse<ApiEventTeacherServerResponseModel>> Update(int eventId,
		                                                                 ApiEventTeacherServerRequestModel model);

		Task<ActionResponse> Delete(int eventId);

		Task<ApiEventTeacherServerResponseModel> Get(int eventId);

		Task<List<ApiEventTeacherServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>0ff916c300d2fa8d753603d8e427619e</Hash>
</Codenesium>*/