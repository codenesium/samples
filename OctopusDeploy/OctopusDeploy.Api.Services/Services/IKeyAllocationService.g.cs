using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IKeyAllocationService
        {
                Task<CreateResponse<ApiKeyAllocationResponseModel>> Create(
                        ApiKeyAllocationRequestModel model);

                Task<ActionResponse> Update(string collectionName,
                                            ApiKeyAllocationRequestModel model);

                Task<ActionResponse> Delete(string collectionName);

                Task<ApiKeyAllocationResponseModel> Get(string collectionName);

                Task<List<ApiKeyAllocationResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>aad40959ebc2d9bb6016f8bb8b75ee8f</Hash>
</Codenesium>*/