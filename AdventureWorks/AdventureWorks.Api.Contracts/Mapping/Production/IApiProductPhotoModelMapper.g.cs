using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductPhotoModelMapper
        {
                ApiProductPhotoResponseModel MapRequestToResponse(
                        int productPhotoID,
                        ApiProductPhotoRequestModel request);

                ApiProductPhotoRequestModel MapResponseToRequest(
                        ApiProductPhotoResponseModel response);

                JsonPatchDocument<ApiProductPhotoRequestModel> CreatePatch(ApiProductPhotoRequestModel model);
        }
}

/*<Codenesium>
    <Hash>47bac3003d4532ac15d51e86761c0571</Hash>
</Codenesium>*/