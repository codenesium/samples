using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IShipMethodService
        {
                Task<CreateResponse<ApiShipMethodResponseModel>> Create(
                        ApiShipMethodRequestModel model);

                Task<ActionResponse> Update(int shipMethodID,
                                            ApiShipMethodRequestModel model);

                Task<ActionResponse> Delete(int shipMethodID);

                Task<ApiShipMethodResponseModel> Get(int shipMethodID);

                Task<List<ApiShipMethodResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiShipMethodResponseModel> GetName(string name);

                Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaders(int shipMethodID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b63cc0dc6280d58bf68a04b6f7a7b06f</Hash>
</Codenesium>*/