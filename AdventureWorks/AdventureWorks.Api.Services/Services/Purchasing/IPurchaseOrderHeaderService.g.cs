using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IPurchaseOrderHeaderService
        {
                Task<CreateResponse<ApiPurchaseOrderHeaderResponseModel>> Create(
                        ApiPurchaseOrderHeaderRequestModel model);

                Task<ActionResponse> Update(int purchaseOrderID,
                                            ApiPurchaseOrderHeaderRequestModel model);

                Task<ActionResponse> Delete(int purchaseOrderID);

                Task<ApiPurchaseOrderHeaderResponseModel> Get(int purchaseOrderID);

                Task<List<ApiPurchaseOrderHeaderResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPurchaseOrderHeaderResponseModel>> ByEmployeeID(int employeeID);
                Task<List<ApiPurchaseOrderHeaderResponseModel>> ByVendorID(int vendorID);

                Task<List<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetails(int purchaseOrderID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b11048893ef4693daa228ebeada76534</Hash>
</Codenesium>*/