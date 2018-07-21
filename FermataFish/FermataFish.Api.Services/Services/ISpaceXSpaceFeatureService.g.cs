using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface ISpaceXSpaceFeatureService
        {
                Task<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>> Create(
                        ApiSpaceXSpaceFeatureRequestModel model);

                Task<UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>> Update(int id,
                                                                                 ApiSpaceXSpaceFeatureRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSpaceXSpaceFeatureResponseModel> Get(int id);

                Task<List<ApiSpaceXSpaceFeatureResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9352196736f6e575d7f3542c06684a7f</Hash>
</Codenesium>*/