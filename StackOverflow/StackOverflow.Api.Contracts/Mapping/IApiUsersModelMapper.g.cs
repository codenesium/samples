using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiUsersModelMapper
        {
                ApiUsersResponseModel MapRequestToResponse(
                        int id,
                        ApiUsersRequestModel request);

                ApiUsersRequestModel MapResponseToRequest(
                        ApiUsersResponseModel response);
        }
}

/*<Codenesium>
    <Hash>00b7a0f822a853429885fca6ec5b3af9</Hash>
</Codenesium>*/