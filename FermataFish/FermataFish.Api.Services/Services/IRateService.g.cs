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

                Task<List<ApiRateResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>a59c691383428507824ff7cdc725576d</Hash>
</Codenesium>*/