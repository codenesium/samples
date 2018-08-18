using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IProjectGroupService
	{
		Task<CreateResponse<ApiProjectGroupResponseModel>> Create(
			ApiProjectGroupRequestModel model);

		Task<UpdateResponse<ApiProjectGroupResponseModel>> Update(string id,
		                                                           ApiProjectGroupRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiProjectGroupResponseModel> Get(string id);

		Task<List<ApiProjectGroupResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiProjectGroupResponseModel> ByName(string name);

		Task<List<ApiProjectGroupResponseModel>> ByDataVersion(byte[] dataVersion, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6b2db986b9cc4eb620426c87f5db0d0f</Hash>
</Codenesium>*/