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

                Task<ActionResponse> Update(Guid rowguid,
                                            ApiDocumentRequestModel model);

                Task<ActionResponse> Delete(Guid rowguid);

                Task<ApiDocumentResponseModel> Get(Guid rowguid);

                Task<List<ApiDocumentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiDocumentResponseModel>> ByFileNameRevision(string fileName, string revision);
        }
}

/*<Codenesium>
    <Hash>dba35cbdfc6c72fa1155fa132b26cc21</Hash>
</Codenesium>*/