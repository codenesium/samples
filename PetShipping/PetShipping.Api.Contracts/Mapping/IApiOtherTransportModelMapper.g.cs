using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiOtherTransportModelMapper
        {
                ApiOtherTransportResponseModel MapRequestToResponse(
                        int id,
                        ApiOtherTransportRequestModel request);

                ApiOtherTransportRequestModel MapResponseToRequest(
                        ApiOtherTransportResponseModel response);

                JsonPatchDocument<ApiOtherTransportRequestModel> CreatePatch(ApiOtherTransportRequestModel model);
        }
}

/*<Codenesium>
    <Hash>08d9fe32271e7ad45276baec39d3f64d</Hash>
</Codenesium>*/