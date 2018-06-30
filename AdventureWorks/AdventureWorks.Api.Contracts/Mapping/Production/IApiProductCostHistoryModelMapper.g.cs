using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductCostHistoryModelMapper
        {
                ApiProductCostHistoryResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductCostHistoryRequestModel request);

                ApiProductCostHistoryRequestModel MapResponseToRequest(
                        ApiProductCostHistoryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>637f5fcc2e06e562511d43bd6fd73d36</Hash>
</Codenesium>*/