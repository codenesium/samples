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

                Task<ActionResponse> Update(string id,
                                            ApiDashboardConfigurationRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiDashboardConfigurationResponseModel> Get(string id);

                Task<List<ApiDashboardConfigurationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e9a944f207f7e7f6234db597f8011b2c</Hash>
</Codenesium>*/