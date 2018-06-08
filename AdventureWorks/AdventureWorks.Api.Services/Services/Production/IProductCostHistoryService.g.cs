using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductCostHistoryService
        {
                Task<CreateResponse<ApiProductCostHistoryResponseModel>> Create(
                        ApiProductCostHistoryRequestModel model);

                Task<ActionResponse> Update(int productID,
                                            ApiProductCostHistoryRequestModel model);

                Task<ActionResponse> Delete(int productID);

                Task<ApiProductCostHistoryResponseModel> Get(int productID);

                Task<List<ApiProductCostHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>ff99592b689e4fc1226dd618163ea4ba</Hash>
</Codenesium>*/