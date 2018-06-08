using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IBOLSpaceMapper
        {
                BOSpace MapModelToBO(
                        int id,
                        ApiSpaceRequestModel model);

                ApiSpaceResponseModel MapBOToModel(
                        BOSpace boSpace);

                List<ApiSpaceResponseModel> MapBOToModel(
                        List<BOSpace> items);
        }
}

/*<Codenesium>
    <Hash>05e86e1af785568b75c1802cdf30926b</Hash>
</Codenesium>*/