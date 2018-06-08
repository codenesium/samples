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

                Task<List<ApiProductInventoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>210fbfa3cff20f16a6636db4eddccf43</Hash>
</Codenesium>*/