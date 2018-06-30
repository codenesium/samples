using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiPersonPhoneModelMapper
        {
                public virtual ApiPersonPhoneResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiPersonPhoneRequestModel request)
                {
                        var response = new ApiPersonPhoneResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.ModifiedDate,
                                               request.PhoneNumber,
                                               request.PhoneNumberTypeID);
                        return response;
                }

                public virtual ApiPersonPhoneRequestModel MapResponseToRequest(
                        ApiPersonPhoneResponseModel response)
                {
                        var request = new ApiPersonPhoneRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.PhoneNumber,
                                response.PhoneNumberTypeID);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>cb530abd97d3b33d0bbee0fb2ff6e792</Hash>
</Codenesium>*/