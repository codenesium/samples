using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLWorkOrderMapper
        {
                BOWorkOrder MapModelToBO(
                        int workOrderID,
                        ApiWorkOrderRequestModel model);

                ApiWorkOrderResponseModel MapBOToModel(
                        BOWorkOrder boWorkOrder);

                List<ApiWorkOrderResponseModel> MapBOToModel(
                        List<BOWorkOrder> items);
        }
}

/*<Codenesium>
    <Hash>d122325e62d34618607c502c8d14dc40</Hash>
</Codenesium>*/