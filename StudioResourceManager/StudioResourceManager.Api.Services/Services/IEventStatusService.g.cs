using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>ecafa792cd9ec8101aef11dbef50721c</Hash>
</Codenesium>*/