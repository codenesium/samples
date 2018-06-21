using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IBOLStudioMapper
        {
                BOStudio MapModelToBO(
                        int id,
                        ApiStudioRequestModel model);

                ApiStudioResponseModel MapBOToModel(
                        BOStudio boStudio);

                List<ApiStudioResponseModel> MapBOToModel(
                        List<BOStudio> items);
        }
}

/*<Codenesium>
    <Hash>c72742716be3fd39ea3e673c5ba980c6</Hash>
</Codenesium>*/