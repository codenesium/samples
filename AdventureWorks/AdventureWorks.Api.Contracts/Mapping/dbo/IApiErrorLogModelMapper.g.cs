using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiErrorLogModelMapper
        {
                ApiErrorLogResponseModel MapRequestToResponse(
                        int errorLogID,
                        ApiErrorLogRequestModel request);

                ApiErrorLogRequestModel MapResponseToRequest(
                        ApiErrorLogResponseModel response);
        }
}

/*<Codenesium>
    <Hash>0c0d7f9b025542b564f7634c2adc21fc</Hash>
</Codenesium>*/