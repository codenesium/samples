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

                Task<List<ApiProductCostHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>f2cd718e4f5a14c2b26b3251c544a629</Hash>
</Codenesium>*/