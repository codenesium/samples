using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiPhoneNumberTypeModelMapper
        {
                ApiPhoneNumberTypeResponseModel MapRequestToResponse(
                        int phoneNumberTypeID,
                        ApiPhoneNumberTypeRequestModel request);

                ApiPhoneNumberTypeRequestModel MapResponseToRequest(
                        ApiPhoneNumberTypeResponseModel response);
        }
}

/*<Codenesium>
    <Hash>485a61c930b33e66887e6b2f445e8cf2</Hash>
</Codenesium>*/