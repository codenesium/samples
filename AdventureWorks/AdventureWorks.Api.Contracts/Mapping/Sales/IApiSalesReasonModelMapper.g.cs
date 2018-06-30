using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesReasonModelMapper
        {
                ApiSalesReasonResponseModel MapRequestToResponse(
                        int salesReasonID,
                        ApiSalesReasonRequestModel request);

                ApiSalesReasonRequestModel MapResponseToRequest(
                        ApiSalesReasonResponseModel response);
        }
}

/*<Codenesium>
    <Hash>a2f2179bbe6748591d54f26a49954f8c</Hash>
</Codenesium>*/