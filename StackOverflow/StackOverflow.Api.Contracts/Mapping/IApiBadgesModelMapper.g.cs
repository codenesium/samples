using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiBadgesModelMapper
        {
                ApiBadgesResponseModel MapRequestToResponse(
                        int id,
                        ApiBadgesRequestModel request);

                ApiBadgesRequestModel MapResponseToRequest(
                        ApiBadgesResponseModel response);
        }
}

/*<Codenesium>
    <Hash>629429c28c5190bcdeb6da280f0e9da1</Hash>
</Codenesium>*/