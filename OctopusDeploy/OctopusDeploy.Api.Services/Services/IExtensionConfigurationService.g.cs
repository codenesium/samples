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

                Task<List<ApiExtensionConfigurationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ef910ffc9b741728d6830a928401815f</Hash>
</Codenesium>*/