using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiPhoneNumberTypeModelMapper
        {
                ApiPhoneNumberTypeResponseModel MapRequestToResponse(
                        int phoneNumberTypeID,
                        ApiPhoneNumberTypeRequestModel request);

                ApiPhoneNumberTypeRequestModel MapResponseToRequest(
                        ApiPhoneNumberTypeResponseModel response);

                JsonPatchDocument<ApiPhoneNumberTypeRequestModel> CreatePatch(ApiPhoneNumberTypeRequestModel model);
        }
}

/*<Codenesium>
    <Hash>7b44c546ee609c922df54378ca046b88</Hash>
</Codenesium>*/