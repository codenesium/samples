using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>8340cb0f4a82cc58bb77db800b832bf9</Hash>
</Codenesium>*/