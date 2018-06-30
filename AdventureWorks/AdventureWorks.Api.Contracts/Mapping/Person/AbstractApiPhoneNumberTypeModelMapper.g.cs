using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiPhoneNumberTypeModelMapper
        {
                public virtual ApiPhoneNumberTypeResponseModel MapRequestToResponse(
                        int phoneNumberTypeID,
                        ApiPhoneNumberTypeRequestModel request)
                {
                        var response = new ApiPhoneNumberTypeResponseModel();
                        response.SetProperties(phoneNumberTypeID,
                                               request.ModifiedDate,
                                               request.Name);
                        return response;
                }

                public virtual ApiPhoneNumberTypeRequestModel MapResponseToRequest(
                        ApiPhoneNumberTypeResponseModel response)
                {
                        var request = new ApiPhoneNumberTypeRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>bb1777aad75b77a7c9a0e207347156f3</Hash>
</Codenesium>*/