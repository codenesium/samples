using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>565d244dc41c9363b86c207468d27c8d</Hash>
</Codenesium>*/