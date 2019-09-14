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

		Task<UpdateResponse<ApiEventTeacherServerResponseModel>> Update(int id,
		                                                                 ApiEventTeacherServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventTeacherServerResponseModel> Get(int id);

		Task<List<ApiEventTeacherServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>13aff813007da571c2f59e0805125d64</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/