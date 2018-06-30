using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiCountryModelMapper
        {
                ApiCountryResponseModel MapRequestToResponse(
                        int id,
                        ApiCountryRequestModel request);

                ApiCountryRequestModel MapResponseToRequest(
                        ApiCountryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>31a39c0ce6927d06379c7e89fb92c20b</Hash>
</Codenesium>*/