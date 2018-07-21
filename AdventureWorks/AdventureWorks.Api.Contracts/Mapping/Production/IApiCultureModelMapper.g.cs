using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiCultureModelMapper
        {
                ApiCultureResponseModel MapRequestToResponse(
                        string cultureID,
                        ApiCultureRequestModel request);

                ApiCultureRequestModel MapResponseToRequest(
                        ApiCultureResponseModel response);

                JsonPatchDocument<ApiCultureRequestModel> CreatePatch(ApiCultureRequestModel model);
        }
}

/*<Codenesium>
    <Hash>b967dd6ba07dc9c4a19ce7ce2a55624a</Hash>
</Codenesium>*/