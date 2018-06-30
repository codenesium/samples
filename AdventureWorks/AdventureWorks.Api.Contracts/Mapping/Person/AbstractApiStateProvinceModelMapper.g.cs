using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiStateProvinceModelMapper
        {
                public virtual ApiStateProvinceResponseModel MapRequestToResponse(
                        int stateProvinceID,
                        ApiStateProvinceRequestModel request)
                {
                        var response = new ApiStateProvinceResponseModel();
                        response.SetProperties(stateProvinceID,
                                               request.CountryRegionCode,
                                               request.IsOnlyStateProvinceFlag,
                                               request.ModifiedDate,
                                               request.Name,
                                               request.Rowguid,
                                               request.StateProvinceCode,
                                               request.TerritoryID);
                        return response;
                }

                public virtual ApiStateProvinceRequestModel MapResponseToRequest(
                        ApiStateProvinceResponseModel response)
                {
                        var request = new ApiStateProvinceRequestModel();
                        request.SetProperties(
                                response.CountryRegionCode,
                                response.IsOnlyStateProvinceFlag,
                                response.ModifiedDate,
                                response.Name,
                                response.Rowguid,
                                response.StateProvinceCode,
                                response.TerritoryID);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>35aee3fb62a7e8789e09b8cc695748e0</Hash>
</Codenesium>*/