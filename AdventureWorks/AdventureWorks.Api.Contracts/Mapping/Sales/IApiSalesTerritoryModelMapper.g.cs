using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesTerritoryModelMapper
        {
                ApiSalesTerritoryResponseModel MapRequestToResponse(
                        int territoryID,
                        ApiSalesTerritoryRequestModel request);

                ApiSalesTerritoryRequestModel MapResponseToRequest(
                        ApiSalesTerritoryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>edc7386433184cca8af9c66ec634ccdf</Hash>
</Codenesium>*/