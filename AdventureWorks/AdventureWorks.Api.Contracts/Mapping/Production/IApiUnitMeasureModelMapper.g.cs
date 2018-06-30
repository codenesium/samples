using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiUnitMeasureModelMapper
        {
                ApiUnitMeasureResponseModel MapRequestToResponse(
                        string unitMeasureCode,
                        ApiUnitMeasureRequestModel request);

                ApiUnitMeasureRequestModel MapResponseToRequest(
                        ApiUnitMeasureResponseModel response);
        }
}

/*<Codenesium>
    <Hash>16508aa39d5b546f76675e20f40bbb02</Hash>
</Codenesium>*/