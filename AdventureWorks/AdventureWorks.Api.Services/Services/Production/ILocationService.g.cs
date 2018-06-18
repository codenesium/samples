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

                Task<List<ApiLocationResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiLocationResponseModel> ByName(string name);

                Task<List<ApiProductInventoryResponseModel>> ProductInventories(short locationID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutings(short locationID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>72d1b49f26a89149ffe8351b225d9c8a</Hash>
</Codenesium>*/