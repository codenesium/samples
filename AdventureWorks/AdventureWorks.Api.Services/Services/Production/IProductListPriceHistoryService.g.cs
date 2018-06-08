using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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

                Task<List<ApiProductListPriceHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>2ab7e21d7afc7cc11a2ce394529254ca</Hash>
</Codenesium>*/