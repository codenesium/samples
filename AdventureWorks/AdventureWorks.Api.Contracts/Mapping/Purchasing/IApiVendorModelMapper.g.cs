using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiVendorModelMapper
        {
                ApiVendorResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiVendorRequestModel request);

                ApiVendorRequestModel MapResponseToRequest(
                        ApiVendorResponseModel response);

                JsonPatchDocument<ApiVendorRequestModel> CreatePatch(ApiVendorRequestModel model);
        }
}

/*<Codenesium>
    <Hash>4e9d652d008e2a3b71caefb1497e6539</Hash>
</Codenesium>*/