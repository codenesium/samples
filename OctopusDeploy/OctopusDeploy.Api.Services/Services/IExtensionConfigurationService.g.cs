using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiExtensionConfigurationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>cc13dbaf0eb8ad4282f484352b834228</Hash>
</Codenesium>*/