using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>ebfb8c25966944a5abd7972bc3f1500d</Hash>
</Codenesium>*/