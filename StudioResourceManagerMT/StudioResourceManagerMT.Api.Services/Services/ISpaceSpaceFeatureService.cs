using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface ISpaceSpaceFeatureService
	{
		Task<CreateResponse<ApiSpaceSpaceFeatureServerResponseModel>> Create(
			ApiSpaceSpaceFeatureServerRequestModel model);

		Task<UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel>> Update(int id,
		                                                                      ApiSpaceSpaceFeatureServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpaceSpaceFeatureServerResponseModel> Get(int id);

		Task<List<ApiSpaceSpaceFeatureServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>9263f92e3260bbe08151942ca35e03c6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/