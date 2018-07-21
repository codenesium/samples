using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiBusinessEntityAddressModelMapper
        {
                public virtual ApiBusinessEntityAddressResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiBusinessEntityAddressRequestModel request)
                {
                        var response = new ApiBusinessEntityAddressResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.AddressID,
                                               request.AddressTypeID,
                                               request.ModifiedDate,
                                               request.Rowguid);
                        return response;
                }

                public virtual ApiBusinessEntityAddressRequestModel MapResponseToRequest(
                        ApiBusinessEntityAddressResponseModel response)
                {
                        var request = new ApiBusinessEntityAddressRequestModel();
                        request.SetProperties(
                                response.AddressID,
                                response.AddressTypeID,
                                response.ModifiedDate,
                                response.Rowguid);
                        return request;
                }

                public JsonPatchDocument<ApiBusinessEntityAddressRequestModel> CreatePatch(ApiBusinessEntityAddressRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiBusinessEntityAddressRequestModel>();
                        patch.Replace(x => x.AddressID, model.AddressID);
                        patch.Replace(x => x.AddressTypeID, model.AddressTypeID);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>4fc0ff576cc1360e32cbd5e9ba114259</Hash>
</Codenesium>*/