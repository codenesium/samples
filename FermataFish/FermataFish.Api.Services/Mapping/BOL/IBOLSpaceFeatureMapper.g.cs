using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IBOLSpaceFeatureMapper
        {
                BOSpaceFeature MapModelToBO(
                        int id,
                        ApiSpaceFeatureRequestModel model);

                ApiSpaceFeatureResponseModel MapBOToModel(
                        BOSpaceFeature boSpaceFeature);

                List<ApiSpaceFeatureResponseModel> MapBOToModel(
                        List<BOSpaceFeature> items);
        }
}

/*<Codenesium>
    <Hash>73413242ea759c7fd115c484aad196f6</Hash>
</Codenesium>*/