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

                Task<List<ApiExtensionConfigurationResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>53f8a890cb5b1e413ffc1c486605800e</Hash>
</Codenesium>*/