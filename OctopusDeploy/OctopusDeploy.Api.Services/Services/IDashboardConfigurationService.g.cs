using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IDashboardConfigurationService
	{
		Task<CreateResponse<ApiDashboardConfigurationResponseModel>> Create(
			ApiDashboardConfigurationRequestModel model);

		Task<UpdateResponse<ApiDashboardConfigurationResponseModel>> Update(string id,
		                                                                     ApiDashboardConfigurationRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiDashboardConfigurationResponseModel> Get(string id);

		Task<List<ApiDashboardConfigurationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2224460af4d8ad0c0e0619f9e63f6769</Hash>
</Codenesium>*/