using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>a2ea88a34e29f7b9dae9b7625b7e8381</Hash>
</Codenesium>*/