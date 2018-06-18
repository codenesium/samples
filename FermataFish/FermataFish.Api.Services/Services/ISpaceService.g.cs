using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface ISpaceService
        {
                Task<CreateResponse<ApiSpaceResponseModel>> Create(
                        ApiSpaceRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiSpaceRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSpaceResponseModel> Get(int id);

                Task<List<ApiSpaceResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatures(int spaceId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>09ab591253b32608e6c7327739eb403d</Hash>
</Codenesium>*/