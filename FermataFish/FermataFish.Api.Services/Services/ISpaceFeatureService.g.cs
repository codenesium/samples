using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>789dd85ed8dbfbe77001a71feaa78fa2</Hash>
</Codenesium>*/