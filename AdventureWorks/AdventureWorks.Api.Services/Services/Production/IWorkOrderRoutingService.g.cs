using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IWorkOrderRoutingService
        {
                Task<CreateResponse<ApiWorkOrderRoutingResponseModel>> Create(
                        ApiWorkOrderRoutingRequestModel model);

                Task<ActionResponse> Update(int workOrderID,
                                            ApiWorkOrderRoutingRequestModel model);

                Task<ActionResponse> Delete(int workOrderID);

                Task<ApiWorkOrderRoutingResponseModel> Get(int workOrderID);

                Task<List<ApiWorkOrderRoutingResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiWorkOrderRoutingResponseModel>> ByProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>67c3df8f5f8315d8df10e4491afa7a72</Hash>
</Codenesium>*/