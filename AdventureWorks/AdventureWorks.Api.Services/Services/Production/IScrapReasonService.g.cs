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

                Task<UpdateResponse<ApiScrapReasonResponseModel>> Update(short scrapReasonID,
                                                                          ApiScrapReasonRequestModel model);

                Task<ActionResponse> Delete(short scrapReasonID);

                Task<ApiScrapReasonResponseModel> Get(short scrapReasonID);

                Task<List<ApiScrapReasonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiScrapReasonResponseModel> ByName(string name);

                Task<List<ApiWorkOrderResponseModel>> WorkOrders(short scrapReasonID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1934f8389c71cb397898e2e4d49243b1</Hash>
</Codenesium>*/