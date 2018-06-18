using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface ISpaceXSpaceFeatureService
        {
                Task<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>> Create(
                        ApiSpaceXSpaceFeatureRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiSpaceXSpaceFeatureRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSpaceXSpaceFeatureResponseModel> Get(int id);

                Task<List<ApiSpaceXSpaceFeatureResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b018c2323596b08262dcf48f6928dc63</Hash>
</Codenesium>*/