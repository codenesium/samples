using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>66b4199fe9274072f8175f428cf83aa2</Hash>
</Codenesium>*/