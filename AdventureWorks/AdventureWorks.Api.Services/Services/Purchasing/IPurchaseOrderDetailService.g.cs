using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IPurchaseOrderDetailService
        {
                Task<CreateResponse<ApiPurchaseOrderDetailResponseModel>> Create(
                        ApiPurchaseOrderDetailRequestModel model);

                Task<ActionResponse> Update(int purchaseOrderID,
                                            ApiPurchaseOrderDetailRequestModel model);

                Task<ActionResponse> Delete(int purchaseOrderID);

                Task<ApiPurchaseOrderDetailResponseModel> Get(int purchaseOrderID);

                Task<List<ApiPurchaseOrderDetailResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPurchaseOrderDetailResponseModel>> ByProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>fc38c2b0a3b4ea0d7af47d683a2eb6ec</Hash>
</Codenesium>*/