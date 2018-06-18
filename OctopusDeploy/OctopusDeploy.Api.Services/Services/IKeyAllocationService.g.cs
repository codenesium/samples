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

                Task<List<ApiKeyAllocationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9f47b652c66695b40cefeb2419c36855</Hash>
</Codenesium>*/