using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiShiftModelMapper
        {
                ApiShiftResponseModel MapRequestToResponse(
                        int shiftID,
                        ApiShiftRequestModel request);

                ApiShiftRequestModel MapResponseToRequest(
                        ApiShiftResponseModel response);

                JsonPatchDocument<ApiShiftRequestModel> CreatePatch(ApiShiftRequestModel model);
        }
}

/*<Codenesium>
    <Hash>e563245572ccb71a3954de7843101136</Hash>
</Codenesium>*/