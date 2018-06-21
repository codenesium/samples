using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiRateResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>03b82fee10b6b2fa8be33a161639e21b</Hash>
</Codenesium>*/