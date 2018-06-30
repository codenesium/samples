using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Contracts
{
        public abstract class AbstractApiPaymentTypeModelMapper
        {
                public virtual ApiPaymentTypeResponseModel MapRequestToResponse(
                        int id,
                        ApiPaymentTypeRequestModel request)
                {
                        var response = new ApiPaymentTypeResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiPaymentTypeRequestModel MapResponseToRequest(
                        ApiPaymentTypeResponseModel response)
                {
                        var request = new ApiPaymentTypeRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>a1d329773d40d27c41077d9007a87448</Hash>
</Codenesium>*/