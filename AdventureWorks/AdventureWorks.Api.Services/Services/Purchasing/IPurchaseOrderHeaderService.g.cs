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

                Task<List<ApiPurchaseOrderHeaderResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiPurchaseOrderHeaderResponseModel>> GetEmployeeID(int employeeID);
                Task<List<ApiPurchaseOrderHeaderResponseModel>> GetVendorID(int vendorID);

                Task<List<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetails(int purchaseOrderID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b8df4338089b68b486312efdf16a86c8</Hash>
</Codenesium>*/