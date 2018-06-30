using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiCommentsModelMapper
        {
                ApiCommentsResponseModel MapRequestToResponse(
                        int id,
                        ApiCommentsRequestModel request);

                ApiCommentsRequestModel MapResponseToRequest(
                        ApiCommentsResponseModel response);
        }
}

/*<Codenesium>
    <Hash>45b5a1224b21832933c6303cb0e14992</Hash>
</Codenesium>*/