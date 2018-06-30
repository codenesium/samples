using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSalesReasonModelMapper
        {
                public virtual ApiSalesReasonResponseModel MapRequestToResponse(
                        int salesReasonID,
                        ApiSalesReasonRequestModel request)
                {
                        var response = new ApiSalesReasonResponseModel();
                        response.SetProperties(salesReasonID,
                                               request.ModifiedDate,
                                               request.Name,
                                               request.ReasonType);
                        return response;
                }

                public virtual ApiSalesReasonRequestModel MapResponseToRequest(
                        ApiSalesReasonResponseModel response)
                {
                        var request = new ApiSalesReasonRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Name,
                                response.ReasonType);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>0bdf3c22dd652ec311f6bad735b7db5d</Hash>
</Codenesium>*/