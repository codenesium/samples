using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductVendorModelMapper
        {
                ApiProductVendorResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductVendorRequestModel request);

                ApiProductVendorRequestModel MapResponseToRequest(
                        ApiProductVendorResponseModel response);

                JsonPatchDocument<ApiProductVendorRequestModel> CreatePatch(ApiProductVendorRequestModel model);
        }
}

/*<Codenesium>
    <Hash>602ffca9695c26594527a57b69aa41e6</Hash>
</Codenesium>*/