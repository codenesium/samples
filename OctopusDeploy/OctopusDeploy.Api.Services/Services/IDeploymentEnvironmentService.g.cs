using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IDeploymentEnvironmentService
	{
		Task<CreateResponse<ApiDeploymentEnvironmentResponseModel>> Create(
			ApiDeploymentEnvironmentRequestModel model);

		Task<UpdateResponse<ApiDeploymentEnvironmentResponseModel>> Update(string id,
		                                                                    ApiDeploymentEnvironmentRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiDeploymentEnvironmentResponseModel> Get(string id);

		Task<List<ApiDeploymentEnvironmentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiDeploymentEnvironmentResponseModel> ByName(string name);

		Task<List<ApiDeploymentEnvironmentResponseModel>> ByDataVersion(byte[] dataVersion);
	}
}

/*<Codenesium>
    <Hash>cda2e8211dc05f4e4b4719b22805b5e0</Hash>
</Codenesium>*/