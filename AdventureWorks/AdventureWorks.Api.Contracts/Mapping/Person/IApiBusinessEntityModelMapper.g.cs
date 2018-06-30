using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiBusinessEntityModelMapper
        {
                ApiBusinessEntityResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiBusinessEntityRequestModel request);

                ApiBusinessEntityRequestModel MapResponseToRequest(
                        ApiBusinessEntityResponseModel response);
        }
}

/*<Codenesium>
    <Hash>81be8d29c26a4292d8354cda8442391e</Hash>
</Codenesium>*/