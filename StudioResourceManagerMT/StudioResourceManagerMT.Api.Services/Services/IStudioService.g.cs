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

		Task<List<ApiStudioServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d1ca75129a142a326350f8f585906375</Hash>
</Codenesium>*/