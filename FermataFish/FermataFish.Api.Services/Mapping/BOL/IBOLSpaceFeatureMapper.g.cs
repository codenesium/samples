using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>d31f2ac59422ac5a9ab1a0b85b13d036</Hash>
</Codenesium>*/