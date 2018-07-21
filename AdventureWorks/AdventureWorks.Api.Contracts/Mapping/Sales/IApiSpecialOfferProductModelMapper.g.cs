using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSpecialOfferProductModelMapper
        {
                ApiSpecialOfferProductResponseModel MapRequestToResponse(
                        int specialOfferID,
                        ApiSpecialOfferProductRequestModel request);

                ApiSpecialOfferProductRequestModel MapResponseToRequest(
                        ApiSpecialOfferProductResponseModel response);

                JsonPatchDocument<ApiSpecialOfferProductRequestModel> CreatePatch(ApiSpecialOfferProductRequestModel model);
        }
}

/*<Codenesium>
    <Hash>b15e9f20ca6405084dd664a3735fd49e</Hash>
</Codenesium>*/