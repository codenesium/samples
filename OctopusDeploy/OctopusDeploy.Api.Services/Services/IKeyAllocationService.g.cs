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

                Task<List<ApiKeyAllocationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>3d28c916bff6f42c7e98e1d247d14443</Hash>
</Codenesium>*/