using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IRateService
        {
                Task<CreateResponse<ApiRateResponseModel>> Create(
                        ApiRateRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiRateRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiRateResponseModel> Get(int id);

                Task<List<ApiRateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>b838d8b1bc04f3fd92f435a643f2e849</Hash>
</Codenesium>*/