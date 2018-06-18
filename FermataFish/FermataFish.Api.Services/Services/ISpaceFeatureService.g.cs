using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface ISpaceFeatureService
        {
                Task<CreateResponse<ApiSpaceFeatureResponseModel>> Create(
                        ApiSpaceFeatureRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiSpaceFeatureRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSpaceFeatureResponseModel> Get(int id);

                Task<List<ApiSpaceFeatureResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatures(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>09319cf37b775737ede481b09be3dbd9</Hash>
</Codenesium>*/