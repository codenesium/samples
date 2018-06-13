using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IStateService
        {
                Task<CreateResponse<ApiStateResponseModel>> Create(
                        ApiStateRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiStateRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiStateResponseModel> Get(int id);

                Task<List<ApiStateResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiStudioResponseModel>> Studios(int stateId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>6873f5fe37fad55882c2ecf1ef38bda3</Hash>
</Codenesium>*/