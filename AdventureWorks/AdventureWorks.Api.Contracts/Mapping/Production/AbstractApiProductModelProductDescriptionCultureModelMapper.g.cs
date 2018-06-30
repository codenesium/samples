using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductModelProductDescriptionCultureModelMapper
        {
                public virtual ApiProductModelProductDescriptionCultureResponseModel MapRequestToResponse(
                        int productModelID,
                        ApiProductModelProductDescriptionCultureRequestModel request)
                {
                        var response = new ApiProductModelProductDescriptionCultureResponseModel();
                        response.SetProperties(productModelID,
                                               request.CultureID,
                                               request.ModifiedDate,
                                               request.ProductDescriptionID);
                        return response;
                }

                public virtual ApiProductModelProductDescriptionCultureRequestModel MapResponseToRequest(
                        ApiProductModelProductDescriptionCultureResponseModel response)
                {
                        var request = new ApiProductModelProductDescriptionCultureRequestModel();
                        request.SetProperties(
                                response.CultureID,
                                response.ModifiedDate,
                                response.ProductDescriptionID);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>fa9e684dfe0675e0c33b000e7eec5b78</Hash>
</Codenesium>*/