using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ILocationService
        {
                Task<CreateResponse<ApiLocationResponseModel>> Create(
                        ApiLocationRequestModel model);

                Task<ActionResponse> Update(short locationID,
                                            ApiLocationRequestModel model);

                Task<ActionResponse> Delete(short locationID);

                Task<ApiLocationResponseModel> Get(short locationID);

                Task<List<ApiLocationResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiLocationResponseModel> GetName(string name);

                Task<List<ApiProductInventoryResponseModel>> ProductInventories(short locationID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutings(short locationID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>76d404221842d052a5c8509c79cf4021</Hash>
</Codenesium>*/