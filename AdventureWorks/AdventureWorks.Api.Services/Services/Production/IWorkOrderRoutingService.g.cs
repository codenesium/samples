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

                Task<List<ApiWorkOrderRoutingResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiWorkOrderRoutingResponseModel>> GetProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>83cb696757b3ae7343f113c5f56a5c09</Hash>
</Codenesium>*/