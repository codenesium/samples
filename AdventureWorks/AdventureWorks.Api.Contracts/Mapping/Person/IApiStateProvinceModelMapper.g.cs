using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiStateProvinceModelMapper
        {
                ApiStateProvinceResponseModel MapRequestToResponse(
                        int stateProvinceID,
                        ApiStateProvinceRequestModel request);

                ApiStateProvinceRequestModel MapResponseToRequest(
                        ApiStateProvinceResponseModel response);
        }
}

/*<Codenesium>
    <Hash>09d45b7d671cbb65afce1e9f6e683d21</Hash>
</Codenesium>*/