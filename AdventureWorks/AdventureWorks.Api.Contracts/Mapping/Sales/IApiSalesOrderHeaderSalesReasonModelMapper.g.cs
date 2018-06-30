using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesOrderHeaderSalesReasonModelMapper
        {
                ApiSalesOrderHeaderSalesReasonResponseModel MapRequestToResponse(
                        int salesOrderID,
                        ApiSalesOrderHeaderSalesReasonRequestModel request);

                ApiSalesOrderHeaderSalesReasonRequestModel MapResponseToRequest(
                        ApiSalesOrderHeaderSalesReasonResponseModel response);
        }
}

/*<Codenesium>
    <Hash>6f4afc7478b64b51f793ec7f08edce0f</Hash>
</Codenesium>*/