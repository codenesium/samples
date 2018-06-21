using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IScrapReasonService
        {
                Task<CreateResponse<ApiScrapReasonResponseModel>> Create(
                        ApiScrapReasonRequestModel model);

                Task<ActionResponse> Update(short scrapReasonID,
                                            ApiScrapReasonRequestModel model);

                Task<ActionResponse> Delete(short scrapReasonID);

                Task<ApiScrapReasonResponseModel> Get(short scrapReasonID);

                Task<List<ApiScrapReasonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiScrapReasonResponseModel> ByName(string name);

                Task<List<ApiWorkOrderResponseModel>> WorkOrders(short scrapReasonID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>28d153dbae7726be90d5dd45bbd15c68</Hash>
</Codenesium>*/