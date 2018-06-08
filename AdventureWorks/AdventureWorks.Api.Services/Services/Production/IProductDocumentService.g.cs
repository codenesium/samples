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

                Task<List<ApiProductDocumentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>a07b2affdc81ccad820a9f7f947d4527</Hash>
</Codenesium>*/