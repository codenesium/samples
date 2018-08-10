using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IProjectTriggerService
	{
		Task<CreateResponse<ApiProjectTriggerResponseModel>> Create(
			ApiProjectTriggerRequestModel model);

		Task<UpdateResponse<ApiProjectTriggerResponseModel>> Update(string id,
		                                                             ApiProjectTriggerRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiProjectTriggerResponseModel> Get(string id);

		Task<List<ApiProjectTriggerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiProjectTriggerResponseModel> ByProjectIdName(string projectId, string name);

		Task<List<ApiProjectTriggerResponseModel>> ByProjectId(string projectId);
	}
}

/*<Codenesium>
    <Hash>1b0cbfb6b4dd680d14825af0cb16887f</Hash>
</Codenesium>*/