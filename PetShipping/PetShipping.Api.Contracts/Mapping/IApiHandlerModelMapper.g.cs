using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiHandlerModelMapper
        {
                ApiHandlerResponseModel MapRequestToResponse(
                        int id,
                        ApiHandlerRequestModel request);

                ApiHandlerRequestModel MapResponseToRequest(
                        ApiHandlerResponseModel response);
        }
}

/*<Codenesium>
    <Hash>4ab76ec6947088d702009c1faa3f1702</Hash>
</Codenesium>*/