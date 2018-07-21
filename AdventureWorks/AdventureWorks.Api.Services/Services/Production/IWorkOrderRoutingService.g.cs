using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IWorkOrderRoutingService
        {
                Task<CreateResponse<ApiWorkOrderRoutingResponseModel>> Create(
                        ApiWorkOrderRoutingRequestModel model);

                Task<UpdateResponse<ApiWorkOrderRoutingResponseModel>> Update(int workOrderID,
                                                                               ApiWorkOrderRoutingRequestModel model);

                Task<ActionResponse> Delete(int workOrderID);

                Task<ApiWorkOrderRoutingResponseModel> Get(int workOrderID);

                Task<List<ApiWorkOrderRoutingResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiWorkOrderRoutingResponseModel>> ByProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>9718536c587f8b1a8fe2ca4b4827559e</Hash>
</Codenesium>*/