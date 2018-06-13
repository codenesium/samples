using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDashboardConfigurationService
        {
                Task<CreateResponse<ApiDashboardConfigurationResponseModel>> Create(
                        ApiDashboardConfigurationRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiDashboardConfigurationRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiDashboardConfigurationResponseModel> Get(string id);

                Task<List<ApiDashboardConfigurationResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>36302571c3db9f72159efab872debc14</Hash>
</Codenesium>*/