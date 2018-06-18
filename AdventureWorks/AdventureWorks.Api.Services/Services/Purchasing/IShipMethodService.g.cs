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

                Task<List<ApiShipMethodResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiShipMethodResponseModel> ByName(string name);

                Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaders(int shipMethodID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ed5d4a7ce53d162667989b311300c0e9</Hash>
</Codenesium>*/