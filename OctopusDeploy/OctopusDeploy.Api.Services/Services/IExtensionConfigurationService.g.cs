using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IExtensionConfigurationService
        {
                Task<CreateResponse<ApiExtensionConfigurationResponseModel>> Create(
                        ApiExtensionConfigurationRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiExtensionConfigurationRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiExtensionConfigurationResponseModel> Get(string id);

                Task<List<ApiExtensionConfigurationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>e97fc9784eb68fee902069d1f9d80d56</Hash>
</Codenesium>*/