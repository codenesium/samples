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

                Task<List<ApiScrapReasonResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiScrapReasonResponseModel> GetName(string name);

                Task<List<ApiWorkOrderResponseModel>> WorkOrders(short scrapReasonID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>0eb8a6d487a225e6dc65c75d8ac30fc7</Hash>
</Codenesium>*/