using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IWorkOrderService
        {
                Task<CreateResponse<ApiWorkOrderResponseModel>> Create(
                        ApiWorkOrderRequestModel model);

                Task<ActionResponse> Update(int workOrderID,
                                            ApiWorkOrderRequestModel model);

                Task<ActionResponse> Delete(int workOrderID);

                Task<ApiWorkOrderResponseModel> Get(int workOrderID);

                Task<List<ApiWorkOrderResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiWorkOrderResponseModel>> ByProductID(int productID);

                Task<List<ApiWorkOrderResponseModel>> ByScrapReasonID(Nullable<short> scrapReasonID);

                Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutings(int workOrderID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ce72c1480a0a5caadc67c1b076e2871f</Hash>
</Codenesium>*/