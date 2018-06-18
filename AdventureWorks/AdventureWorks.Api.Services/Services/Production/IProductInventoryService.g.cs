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

                Task<List<ApiProductInventoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d77448c7df4c7fcfbe360b500fa2b62e</Hash>
</Codenesium>*/