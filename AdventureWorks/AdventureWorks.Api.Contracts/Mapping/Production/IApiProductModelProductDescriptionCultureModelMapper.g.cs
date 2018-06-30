using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductModelProductDescriptionCultureModelMapper
        {
                ApiProductModelProductDescriptionCultureResponseModel MapRequestToResponse(
                        int productModelID,
                        ApiProductModelProductDescriptionCultureRequestModel request);

                ApiProductModelProductDescriptionCultureRequestModel MapResponseToRequest(
                        ApiProductModelProductDescriptionCultureResponseModel response);
        }
}

/*<Codenesium>
    <Hash>761b3565b108331792a5a12cd7ae6ffc</Hash>
</Codenesium>*/