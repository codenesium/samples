using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiBusinessEntityContactModelMapper
        {
                ApiBusinessEntityContactResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiBusinessEntityContactRequestModel request);

                ApiBusinessEntityContactRequestModel MapResponseToRequest(
                        ApiBusinessEntityContactResponseModel response);

                JsonPatchDocument<ApiBusinessEntityContactRequestModel> CreatePatch(ApiBusinessEntityContactRequestModel model);
        }
}

/*<Codenesium>
    <Hash>ca9dc41535eab7ff951783e6f9aa26de</Hash>
</Codenesium>*/