using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiAddressTypeModelMapper
        {
                ApiAddressTypeResponseModel MapRequestToResponse(
                        int addressTypeID,
                        ApiAddressTypeRequestModel request);

                ApiAddressTypeRequestModel MapResponseToRequest(
                        ApiAddressTypeResponseModel response);

                JsonPatchDocument<ApiAddressTypeRequestModel> CreatePatch(ApiAddressTypeRequestModel model);
        }
}

/*<Codenesium>
    <Hash>0d28c4bdf506855dedec5c2f02f58e57</Hash>
</Codenesium>*/