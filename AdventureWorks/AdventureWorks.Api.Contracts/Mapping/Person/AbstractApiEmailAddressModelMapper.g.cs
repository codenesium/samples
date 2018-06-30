using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiEmailAddressModelMapper
        {
                public virtual ApiEmailAddressResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiEmailAddressRequestModel request)
                {
                        var response = new ApiEmailAddressResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.EmailAddress1,
                                               request.EmailAddressID,
                                               request.ModifiedDate,
                                               request.Rowguid);
                        return response;
                }

                public virtual ApiEmailAddressRequestModel MapResponseToRequest(
                        ApiEmailAddressResponseModel response)
                {
                        var request = new ApiEmailAddressRequestModel();
                        request.SetProperties(
                                response.EmailAddress1,
                                response.EmailAddressID,
                                response.ModifiedDate,
                                response.Rowguid);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>069890a94ff0f29d7d9365ef209841a4</Hash>
</Codenesium>*/