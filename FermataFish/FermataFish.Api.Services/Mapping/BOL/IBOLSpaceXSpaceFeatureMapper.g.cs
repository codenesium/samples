using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IBOLSpaceXSpaceFeatureMapper
        {
                BOSpaceXSpaceFeature MapModelToBO(
                        int id,
                        ApiSpaceXSpaceFeatureRequestModel model);

                ApiSpaceXSpaceFeatureResponseModel MapBOToModel(
                        BOSpaceXSpaceFeature boSpaceXSpaceFeature);

                List<ApiSpaceXSpaceFeatureResponseModel> MapBOToModel(
                        List<BOSpaceXSpaceFeature> items);
        }
}

/*<Codenesium>
    <Hash>db598b5317f0929ffb3d38e60b2f1d5a</Hash>
</Codenesium>*/