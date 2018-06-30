using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSalesOrderHeaderSalesReasonModelMapper
        {
                public virtual ApiSalesOrderHeaderSalesReasonResponseModel MapRequestToResponse(
                        int salesOrderID,
                        ApiSalesOrderHeaderSalesReasonRequestModel request)
                {
                        var response = new ApiSalesOrderHeaderSalesReasonResponseModel();
                        response.SetProperties(salesOrderID,
                                               request.ModifiedDate,
                                               request.SalesReasonID);
                        return response;
                }

                public virtual ApiSalesOrderHeaderSalesReasonRequestModel MapResponseToRequest(
                        ApiSalesOrderHeaderSalesReasonResponseModel response)
                {
                        var request = new ApiSalesOrderHeaderSalesReasonRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.SalesReasonID);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>f0e95e3e5c227bd7b138da4ffafc536f</Hash>
</Codenesium>*/