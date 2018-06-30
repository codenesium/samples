using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductProductPhotoModelMapper
        {
                ApiProductProductPhotoResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductProductPhotoRequestModel request);

                ApiProductProductPhotoRequestModel MapResponseToRequest(
                        ApiProductProductPhotoResponseModel response);
        }
}

/*<Codenesium>
    <Hash>1955ffa7893f4fbc0c420993b2b6658c</Hash>
</Codenesium>*/