using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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

                Task<List<ApiApiKeyResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiApiKeyResponseModel> GetApiKeyHashed(string apiKeyHashed);
        }
}

/*<Codenesium>
    <Hash>040f6380e46a5c88ae09aded36eede7b</Hash>
</Codenesium>*/