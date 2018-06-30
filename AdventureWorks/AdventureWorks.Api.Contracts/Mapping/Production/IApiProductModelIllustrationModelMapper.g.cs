using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductModelIllustrationModelMapper
        {
                ApiProductModelIllustrationResponseModel MapRequestToResponse(
                        int productModelID,
                        ApiProductModelIllustrationRequestModel request);

                ApiProductModelIllustrationRequestModel MapResponseToRequest(
                        ApiProductModelIllustrationResponseModel response);
        }
}

/*<Codenesium>
    <Hash>872fdc4653fc3237f8c63cea12b02c73</Hash>
</Codenesium>*/