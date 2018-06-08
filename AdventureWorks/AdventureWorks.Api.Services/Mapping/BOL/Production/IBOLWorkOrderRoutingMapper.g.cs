using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>6dc5b7d10e363e4dcdfc0f3f50f79163</Hash>
</Codenesium>*/