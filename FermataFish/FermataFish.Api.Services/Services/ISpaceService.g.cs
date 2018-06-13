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

                Task<List<ApiSpaceResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatures(int spaceId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>4787dd53ee38d1a69246d5c9f2fafbff</Hash>
</Codenesium>*/