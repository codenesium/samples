using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiBillOfMaterialsModelMapper
        {
                ApiBillOfMaterialsResponseModel MapRequestToResponse(
                        int billOfMaterialsID,
                        ApiBillOfMaterialsRequestModel request);

                ApiBillOfMaterialsRequestModel MapResponseToRequest(
                        ApiBillOfMaterialsResponseModel response);
        }
}

/*<Codenesium>
    <Hash>a0416ec3ce118cbb124788a6d99e221a</Hash>
</Codenesium>*/