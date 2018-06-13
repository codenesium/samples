using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDocumentService
        {
                Task<CreateResponse<ApiDocumentResponseModel>> Create(
                        ApiDocumentRequestModel model);

                Task<ActionResponse> Update(Guid documentNode,
                                            ApiDocumentRequestModel model);

                Task<ActionResponse> Delete(Guid documentNode);

                Task<ApiDocumentResponseModel> Get(Guid documentNode);

                Task<List<ApiDocumentResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiDocumentResponseModel> GetDocumentLevelDocumentNode(Nullable<short> documentLevel, Guid documentNode);
                Task<List<ApiDocumentResponseModel>> GetFileNameRevision(string fileName, string revision);

                Task<List<ApiProductDocumentResponseModel>> ProductDocuments(Guid documentNode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>eb7813d6b4911688c5642cd89310bece</Hash>
</Codenesium>*/