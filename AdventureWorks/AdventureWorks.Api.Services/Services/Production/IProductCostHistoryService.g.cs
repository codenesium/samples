using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiProductCostHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9b19a227c57245c33435bd3f6c1464d2</Hash>
</Codenesium>*/