using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiAddressModelMapper
        {
                ApiAddressResponseModel MapRequestToResponse(
                        int addressID,
                        ApiAddressRequestModel request);

                ApiAddressRequestModel MapResponseToRequest(
                        ApiAddressResponseModel response);

                JsonPatchDocument<ApiAddressRequestModel> CreatePatch(ApiAddressRequestModel model);
        }
}

/*<Codenesium>
    <Hash>e7e9e6ce8f2606bc487447bcf7a5df4e</Hash>
</Codenesium>*/