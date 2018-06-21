using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiKeyService
        {
                Task<CreateResponse<ApiApiKeyResponseModel>> Create(
                        ApiApiKeyRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiApiKeyRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiApiKeyResponseModel> Get(string id);

                Task<List<ApiApiKeyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiApiKeyResponseModel> GetApiKeyHashed(string apiKeyHashed);
        }
}

/*<Codenesium>
    <Hash>58d2082202976f0edd65f7a15786e6cf</Hash>
</Codenesium>*/