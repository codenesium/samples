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

                Task<List<ApiDashboardConfigurationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>fb43d6ae79133fdf732131c6d3bdb0de</Hash>
</Codenesium>*/