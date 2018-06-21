using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLWorkOrderRoutingMapper
        {
                BOWorkOrderRouting MapModelToBO(
                        int workOrderID,
                        ApiWorkOrderRoutingRequestModel model);

                ApiWorkOrderRoutingResponseModel MapBOToModel(
                        BOWorkOrderRouting boWorkOrderRouting);

                List<ApiWorkOrderRoutingResponseModel> MapBOToModel(
                        List<BOWorkOrderRouting> items);
        }
}

/*<Codenesium>
    <Hash>2e31476a5fd994851efb5690b39b055d</Hash>
</Codenesium>*/