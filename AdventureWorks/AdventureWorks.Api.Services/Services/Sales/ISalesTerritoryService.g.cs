using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ISalesTerritoryService
        {
                Task<CreateResponse<ApiSalesTerritoryResponseModel>> Create(
                        ApiSalesTerritoryRequestModel model);

                Task<ActionResponse> Update(int territoryID,
                                            ApiSalesTerritoryRequestModel model);

                Task<ActionResponse> Delete(int territoryID);

                Task<ApiSalesTerritoryResponseModel> Get(int territoryID);

                Task<List<ApiSalesTerritoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiSalesTerritoryResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>3101feb0eeb9711f109cd7b90af7d172</Hash>
</Codenesium>*/