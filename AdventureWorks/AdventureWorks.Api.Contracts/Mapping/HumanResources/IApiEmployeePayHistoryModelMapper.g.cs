using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiEmployeePayHistoryModelMapper
        {
                ApiEmployeePayHistoryResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiEmployeePayHistoryRequestModel request);

                ApiEmployeePayHistoryRequestModel MapResponseToRequest(
                        ApiEmployeePayHistoryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>359833a94df2903050c9ee8d91fac298</Hash>
</Codenesium>*/