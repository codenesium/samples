using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiKeyAllocationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c718dc2d658d5aadefc44e1202a32317</Hash>
</Codenesium>*/