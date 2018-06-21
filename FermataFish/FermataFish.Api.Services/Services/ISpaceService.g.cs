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

                Task<ActionResponse> Update(int id,
                                            ApiSpaceRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSpaceResponseModel> Get(int id);

                Task<List<ApiSpaceResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatures(int spaceId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>cb92b0d1f5853ee90d9a4c29bc5c5c4c</Hash>
</Codenesium>*/