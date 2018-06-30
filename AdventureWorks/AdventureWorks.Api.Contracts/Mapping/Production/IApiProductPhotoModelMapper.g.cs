using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductPhotoModelMapper
        {
                ApiProductPhotoResponseModel MapRequestToResponse(
                        int productPhotoID,
                        ApiProductPhotoRequestModel request);

                ApiProductPhotoRequestModel MapResponseToRequest(
                        ApiProductPhotoResponseModel response);
        }
}

/*<Codenesium>
    <Hash>9bd49cd30f1d1f19118b1c9f3a05c541</Hash>
</Codenesium>*/