using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface ISalesTerritoryHistoryService
        {
                Task<CreateResponse<ApiSalesTerritoryHistoryResponseModel>> Create(
                        ApiSalesTerritoryHistoryRequestModel model);

                Task<UpdateResponse<ApiSalesTerritoryHistoryResponseModel>> Update(int businessEntityID,
                                                                                    ApiSalesTerritoryHistoryRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiSalesTerritoryHistoryResponseModel> Get(int businessEntityID);

                Task<List<ApiSalesTerritoryHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>cfb630ecfd742b67983aa33ba5853a74</Hash>
</Codenesium>*/