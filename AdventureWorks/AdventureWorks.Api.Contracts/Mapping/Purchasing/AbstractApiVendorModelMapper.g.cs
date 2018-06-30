using System;
using System.Collections.Generic;

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
                                               request.PreferredVendorStatus,
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
                                response.PreferredVendorStatus,
                                response.PurchasingWebServiceURL);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>1d59ba0b4e887f91c81399cb2b93da12</Hash>
</Codenesium>*/