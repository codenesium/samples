using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductListPriceHistoryService
        {
                Task<CreateResponse<ApiProductListPriceHistoryResponseModel>> Create(
                        ApiProductListPriceHistoryRequestModel model);

                Task<ActionResponse> Update(int productID,
                                            ApiProductListPriceHistoryRequestModel model);

                Task<ActionResponse> Delete(int productID);

                Task<ApiProductListPriceHistoryResponseModel> Get(int productID);

                Task<List<ApiProductListPriceHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e5bb0898abc016f87ab625393473f2b8</Hash>
</Codenesium>*/