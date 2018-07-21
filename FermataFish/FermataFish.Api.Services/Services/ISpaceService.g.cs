using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface ISpaceService
        {
                Task<CreateResponse<ApiSpaceResponseModel>> Create(
                        ApiSpaceRequestModel model);

                Task<UpdateResponse<ApiSpaceResponseModel>> Update(int id,
                                                                    ApiSpaceRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSpaceResponseModel> Get(int id);

                Task<List<ApiSpaceResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatures(int spaceId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f57e5bdb4061de66756d1542ab3fb0ef</Hash>
</Codenesium>*/