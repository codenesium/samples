using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiVendorModelMapper
        {
                public virtual ApiVendorResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiVendorRequestModel request)
                {
                        var response = new ApiVendorResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.AccountNumber,
                                               request.ActiveFlag,
                                               request.CreditRating,
                                               request.ModifiedDate,
                                               request.Name,
                                               request.PreferredVendorStatu,
                                               request.PurchasingWebServiceURL);
                        return response;
                }

                public virtual ApiVendorRequestModel MapResponseToRequest(
                        ApiVendorResponseModel response)
                {
                        var request = new ApiVendorRequestModel();
                        request.SetProperties(
                                response.AccountNumber,
                                response.ActiveFlag,
                                response.CreditRating,
                                response.ModifiedDate,
                                response.Name,
                                response.PreferredVendorStatu,
                                response.PurchasingWebServiceURL);
                        return request;
                }

                public JsonPatchDocument<ApiVendorRequestModel> CreatePatch(ApiVendorRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiVendorRequestModel>();
                        patch.Replace(x => x.AccountNumber, model.AccountNumber);
                        patch.Replace(x => x.ActiveFlag, model.ActiveFlag);
                        patch.Replace(x => x.CreditRating, model.CreditRating);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.PreferredVendorStatu, model.PreferredVendorStatu);
                        patch.Replace(x => x.PurchasingWebServiceURL, model.PurchasingWebServiceURL);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>c56738e67e86029ec51a07362d702206</Hash>
</Codenesium>*/