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

                Task<List<ApiDashboardConfigurationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>76acde9a461ac9bbcde2ac6ecd2b9178</Hash>
</Codenesium>*/