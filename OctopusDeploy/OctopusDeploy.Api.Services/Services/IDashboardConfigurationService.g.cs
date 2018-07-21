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
    <Hash>cdec84dbd5d890ecd8ed2f4a82bea329</Hash>
</Codenesium>*/