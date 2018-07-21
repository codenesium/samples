using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiCountryModelMapper
        {
                ApiCountryResponseModel MapRequestToResponse(
                        int id,
                        ApiCountryRequestModel request);

                ApiCountryRequestModel MapResponseToRequest(
                        ApiCountryResponseModel response);

                JsonPatchDocument<ApiCountryRequestModel> CreatePatch(ApiCountryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>98eafdd83cf1f1437c322c57896d5bd4</Hash>
</Codenesium>*/