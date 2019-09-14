using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IEventStatusService
	{
		Task<CreateResponse<ApiEventStatusServerResponseModel>> Create(
			ApiEventStatusServerRequestModel model);

		Task<UpdateResponse<ApiEventStatusServerResponseModel>> Update(int id,
		                                                                ApiEventStatusServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventStatusServerResponseModel> Get(int id);

		Task<List<ApiEventStatusServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiEventServerResponseModel>> EventsByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7abd44d61051f826f43f01c3aae0d9f0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/