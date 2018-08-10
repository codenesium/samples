using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IOctopusServerNodeService
	{
		Task<CreateResponse<ApiOctopusServerNodeResponseModel>> Create(
			ApiOctopusServerNodeRequestModel model);

		Task<UpdateResponse<ApiOctopusServerNodeResponseModel>> Update(string id,
		                                                                ApiOctopusServerNodeRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiOctopusServerNodeResponseModel> Get(string id);

		Task<List<ApiOctopusServerNodeResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c622c658e0e68bb97b1ad5a5a4762099</Hash>
</Codenesium>*/