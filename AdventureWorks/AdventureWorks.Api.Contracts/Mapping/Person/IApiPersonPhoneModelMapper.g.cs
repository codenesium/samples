using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiPersonPhoneModelMapper
        {
                ApiPersonPhoneResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiPersonPhoneRequestModel request);

                ApiPersonPhoneRequestModel MapResponseToRequest(
                        ApiPersonPhoneResponseModel response);
        }
}

/*<Codenesium>
    <Hash>520700424044a159353b485ce05d94e0</Hash>
</Codenesium>*/