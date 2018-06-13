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

                Task<List<ApiProductListPriceHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>19725e28f4d3b6792dd4e545edcc7813</Hash>
</Codenesium>*/