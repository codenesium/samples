using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductInventoryService
        {
                Task<CreateResponse<ApiProductInventoryResponseModel>> Create(
                        ApiProductInventoryRequestModel model);

                Task<ActionResponse> Update(int productID,
                                            ApiProductInventoryRequestModel model);

                Task<ActionResponse> Delete(int productID);

                Task<ApiProductInventoryResponseModel> Get(int productID);

                Task<List<ApiProductInventoryResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>3b5f83c5566b6c73216e12eb08a51b6f</Hash>
</Codenesium>*/