using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductDocumentService
        {
                Task<CreateResponse<ApiProductDocumentResponseModel>> Create(
                        ApiProductDocumentRequestModel model);

                Task<ActionResponse> Update(int productID,
                                            ApiProductDocumentRequestModel model);

                Task<ActionResponse> Delete(int productID);

                Task<ApiProductDocumentResponseModel> Get(int productID);

                Task<List<ApiProductDocumentResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>e0eb339027e1b262823d6e133ce0a0dc</Hash>
</Codenesium>*/