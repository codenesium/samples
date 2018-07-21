using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductModelMapper
        {
                ApiProductResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductRequestModel request);

                ApiProductRequestModel MapResponseToRequest(
                        ApiProductResponseModel response);

                JsonPatchDocument<ApiProductRequestModel> CreatePatch(ApiProductRequestModel model);
        }
}

/*<Codenesium>
    <Hash>f33c3172e5f6342fc11b2522a7b10b4e</Hash>
</Codenesium>*/