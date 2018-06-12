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

                Task<List<ApiApiKeyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiApiKeyResponseModel> GetApiKeyHashed(string apiKeyHashed);
        }
}

/*<Codenesium>
    <Hash>7767872d34eb5b9cdf3536f059aabde3</Hash>
</Codenesium>*/