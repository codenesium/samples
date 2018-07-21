using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiCityModelMapper
        {
                ApiCityResponseModel MapRequestToResponse(
                        int id,
                        ApiCityRequestModel request);

                ApiCityRequestModel MapResponseToRequest(
                        ApiCityResponseModel response);

                JsonPatchDocument<ApiCityRequestModel> CreatePatch(ApiCityRequestModel model);
        }
}

/*<Codenesium>
    <Hash>432ff7d32bd49d88cb5c9bdbc427f15c</Hash>
</Codenesium>*/