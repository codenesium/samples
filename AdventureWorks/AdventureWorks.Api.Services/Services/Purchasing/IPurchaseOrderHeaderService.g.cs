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

                Task<List<ApiPurchaseOrderHeaderResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiPurchaseOrderHeaderResponseModel>> GetEmployeeID(int employeeID);
                Task<List<ApiPurchaseOrderHeaderResponseModel>> GetVendorID(int vendorID);
        }
}

/*<Codenesium>
    <Hash>624f64090e9287a76386bdf52ee99234</Hash>
</Codenesium>*/