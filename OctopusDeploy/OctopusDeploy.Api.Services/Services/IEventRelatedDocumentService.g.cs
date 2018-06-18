using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IEventRelatedDocumentService
        {
                Task<CreateResponse<ApiEventRelatedDocumentResponseModel>> Create(
                        ApiEventRelatedDocumentRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiEventRelatedDocumentRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiEventRelatedDocumentResponseModel> Get(int id);

                Task<List<ApiEventRelatedDocumentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiEventRelatedDocumentResponseModel>> GetEventId(string eventId);
                Task<List<ApiEventRelatedDocumentResponseModel>> GetEventIdRelatedDocumentId(string eventId, string relatedDocumentId);
        }
}

/*<Codenesium>
    <Hash>6da01bc54a9ef050c80bf28c29881539</Hash>
</Codenesium>*/