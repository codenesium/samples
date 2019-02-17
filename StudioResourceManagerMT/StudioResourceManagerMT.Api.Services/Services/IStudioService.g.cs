using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IStudioService
	{
		Task<CreateResponse<ApiStudioServerResponseModel>> Create(
			ApiStudioServerRequestModel model);

		Task<UpdateResponse<ApiStudioServerResponseModel>> Update(int id,
		                                                           ApiStudioServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStudioServerResponseModel> Get(int id);

		Task<List<ApiStudioServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>a49721e586e5d9e757eb7a6f42dd63a2</Hash>
</Codenesium>*/