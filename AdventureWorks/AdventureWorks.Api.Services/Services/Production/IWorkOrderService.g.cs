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

                Task<List<ApiWorkOrderResponseModel>> ByScrapReasonID(short? scrapReasonID);

                Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutings(int workOrderID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c083c19febdc8050c9ec9c75d110c444</Hash>
</Codenesium>*/