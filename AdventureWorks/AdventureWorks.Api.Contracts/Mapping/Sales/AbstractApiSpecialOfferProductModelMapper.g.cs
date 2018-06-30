using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSpecialOfferProductModelMapper
        {
                public virtual ApiSpecialOfferProductResponseModel MapRequestToResponse(
                        int specialOfferID,
                        ApiSpecialOfferProductRequestModel request)
                {
                        var response = new ApiSpecialOfferProductResponseModel();
                        response.SetProperties(specialOfferID,
                                               request.ModifiedDate,
                                               request.ProductID,
                                               request.Rowguid);
                        return response;
                }

                public virtual ApiSpecialOfferProductRequestModel MapResponseToRequest(
                        ApiSpecialOfferProductResponseModel response)
                {
                        var request = new ApiSpecialOfferProductRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.ProductID,
                                response.Rowguid);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>5e1d5cc3ac24ac81bbedd83a49ac10b1</Hash>
</Codenesium>*/