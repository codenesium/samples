using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiShiftModelMapper
        {
                ApiShiftResponseModel MapRequestToResponse(
                        int shiftID,
                        ApiShiftRequestModel request);

                ApiShiftRequestModel MapResponseToRequest(
                        ApiShiftResponseModel response);
        }
}

/*<Codenesium>
    <Hash>1ca3522cf8f38e81bdff9b5f6733170a</Hash>
</Codenesium>*/