using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>197885c2cf29104d2bde0d0341fbb2e2</Hash>
</Codenesium>*/