using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiUnitMeasureModelMapper
        {
                public virtual ApiUnitMeasureResponseModel MapRequestToResponse(
                        string unitMeasureCode,
                        ApiUnitMeasureRequestModel request)
                {
                        var response = new ApiUnitMeasureResponseModel();
                        response.SetProperties(unitMeasureCode,
                                               request.ModifiedDate,
                                               request.Name);
                        return response;
                }

                public virtual ApiUnitMeasureRequestModel MapResponseToRequest(
                        ApiUnitMeasureResponseModel response)
                {
                        var request = new ApiUnitMeasureRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>03e7de5407b4bf2484360df2be34b7d8</Hash>
</Codenesium>*/