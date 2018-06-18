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

                Task<List<ApiProductCostHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ac3b321b4aee3e547b8536ae7d52bdf2</Hash>
</Codenesium>*/