using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IEventService
        {
                Task<CreateResponse<ApiEventResponseModel>> Create(
                        ApiEventRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiEventRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiEventResponseModel> Get(string id);

                Task<List<ApiEventResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiEventResponseModel>> GetAutoId(long autoId);
                Task<List<ApiEventResponseModel>> GetIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTime occurred, string category, long autoId);
                Task<List<ApiEventResponseModel>> GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTime occurred, string tenantId);
                Task<List<ApiEventResponseModel>> GetIdOccurred(string id, DateTime occurred);
        }
}

/*<Codenesium>
    <Hash>1780ecd7ddc16ee3a02047416e1dfaab</Hash>
</Codenesium>*/