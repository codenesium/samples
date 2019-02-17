using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IFamilyService
	{
		Task<CreateResponse<ApiFamilyServerResponseModel>> Create(
			ApiFamilyServerRequestModel model);

		Task<UpdateResponse<ApiFamilyServerResponseModel>> Update(int id,
		                                                           ApiFamilyServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiFamilyServerResponseModel> Get(int id);

		Task<List<ApiFamilyServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>52b70fb732b6a0e41b21e6f4420a9d29</Hash>
</Codenesium>*/