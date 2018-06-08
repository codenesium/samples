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

                Task<List<ApiScrapReasonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiScrapReasonResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>6b172c1d75e975dc7805ccc43f7dcaf5</Hash>
</Codenesium>*/