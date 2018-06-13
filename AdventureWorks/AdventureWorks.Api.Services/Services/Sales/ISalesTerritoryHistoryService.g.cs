using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ISalesTerritoryHistoryService
        {
                Task<CreateResponse<ApiSalesTerritoryHistoryResponseModel>> Create(
                        ApiSalesTerritoryHistoryRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiSalesTerritoryHistoryRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiSalesTerritoryHistoryResponseModel> Get(int businessEntityID);

                Task<List<ApiSalesTerritoryHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>264ddac382f10513c0e3714df08ea4ba</Hash>
</Codenesium>*/