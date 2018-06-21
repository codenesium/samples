using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IVendorService
        {
                Task<CreateResponse<ApiVendorResponseModel>> Create(
                        ApiVendorRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiVendorRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiVendorResponseModel> Get(int businessEntityID);

                Task<List<ApiVendorResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiVendorResponseModel> ByAccountNumber(string accountNumber);

                Task<List<ApiProductVendorResponseModel>> ProductVendors(int businessEntityID, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaders(int vendorID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>6aec116f463bf7319367a20f0626c91b</Hash>
</Codenesium>*/