using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSpecialOfferModelMapper
        {
                public virtual ApiSpecialOfferResponseModel MapRequestToResponse(
                        int specialOfferID,
                        ApiSpecialOfferRequestModel request)
                {
                        var response = new ApiSpecialOfferResponseModel();
                        response.SetProperties(specialOfferID,
                                               request.Category,
                                               request.Description,
                                               request.DiscountPct,
                                               request.EndDate,
                                               request.MaxQty,
                                               request.MinQty,
                                               request.ModifiedDate,
                                               request.Rowguid,
                                               request.StartDate,
                                               request.Type);
                        return response;
                }

                public virtual ApiSpecialOfferRequestModel MapResponseToRequest(
                        ApiSpecialOfferResponseModel response)
                {
                        var request = new ApiSpecialOfferRequestModel();
                        request.SetProperties(
                                response.Category,
                                response.Description,
                                response.DiscountPct,
                                response.EndDate,
                                response.MaxQty,
                                response.MinQty,
                                response.ModifiedDate,
                                response.Rowguid,
                                response.StartDate,
                                response.Type);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>a79edec2e7d4c0c5280182aa910ea408</Hash>
</Codenesium>*/