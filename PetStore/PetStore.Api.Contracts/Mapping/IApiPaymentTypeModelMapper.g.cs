using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Contracts
{
        public interface IApiPaymentTypeModelMapper
        {
                ApiPaymentTypeResponseModel MapRequestToResponse(
                        int id,
                        ApiPaymentTypeRequestModel request);

                ApiPaymentTypeRequestModel MapResponseToRequest(
                        ApiPaymentTypeResponseModel response);
        }
}

/*<Codenesium>
    <Hash>386025ac03c75133abe1494d2f08a62c</Hash>
</Codenesium>*/