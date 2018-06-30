using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiAddressTypeModelMapper
        {
                ApiAddressTypeResponseModel MapRequestToResponse(
                        int addressTypeID,
                        ApiAddressTypeRequestModel request);

                ApiAddressTypeRequestModel MapResponseToRequest(
                        ApiAddressTypeResponseModel response);
        }
}

/*<Codenesium>
    <Hash>869a92d006858db6cd64b4073b9ce704</Hash>
</Codenesium>*/