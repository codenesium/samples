using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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

                Task<List<ApiVendorResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiVendorResponseModel> GetAccountNumber(string accountNumber);

                Task<List<ApiProductVendorResponseModel>> ProductVendors(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaders(int vendorID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>10f2f7c684b00dac17cb04d982337721</Hash>
</Codenesium>*/