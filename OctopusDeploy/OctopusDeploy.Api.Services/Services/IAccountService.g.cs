using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IAccountService
	{
		Task<CreateResponse<ApiAccountResponseModel>> Create(
			ApiAccountRequestModel model);

		Task<UpdateResponse<ApiAccountResponseModel>> Update(string id,
		                                                      ApiAccountRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiAccountResponseModel> Get(string id);

		Task<List<ApiAccountResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiAccountResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>939dc9925238563273bf5dc44a38147c</Hash>
</Codenesium>*/