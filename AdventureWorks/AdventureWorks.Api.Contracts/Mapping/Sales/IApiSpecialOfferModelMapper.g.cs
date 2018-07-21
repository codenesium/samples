using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSpecialOfferModelMapper
        {
                ApiSpecialOfferResponseModel MapRequestToResponse(
                        int specialOfferID,
                        ApiSpecialOfferRequestModel request);

                ApiSpecialOfferRequestModel MapResponseToRequest(
                        ApiSpecialOfferResponseModel response);

                JsonPatchDocument<ApiSpecialOfferRequestModel> CreatePatch(ApiSpecialOfferRequestModel model);
        }
}

/*<Codenesium>
    <Hash>c34d2a53f7a9378436b226656568ad77</Hash>
</Codenesium>*/