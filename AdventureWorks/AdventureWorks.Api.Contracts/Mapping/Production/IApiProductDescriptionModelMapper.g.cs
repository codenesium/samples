using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductDescriptionModelMapper
        {
                ApiProductDescriptionResponseModel MapRequestToResponse(
                        int productDescriptionID,
                        ApiProductDescriptionRequestModel request);

                ApiProductDescriptionRequestModel MapResponseToRequest(
                        ApiProductDescriptionResponseModel response);
        }
}

/*<Codenesium>
    <Hash>c2fba0cb33177ea0e8cf175354ab15a8</Hash>
</Codenesium>*/