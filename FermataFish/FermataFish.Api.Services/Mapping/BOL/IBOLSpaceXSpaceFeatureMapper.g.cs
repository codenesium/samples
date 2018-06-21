using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>c8df3f614652e0f7a45057fcac8e4baa</Hash>
</Codenesium>*/