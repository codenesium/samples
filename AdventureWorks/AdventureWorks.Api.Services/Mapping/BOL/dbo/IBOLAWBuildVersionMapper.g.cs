using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLAWBuildVersionMapper
        {
                BOAWBuildVersion MapModelToBO(
                        int systemInformationID,
                        ApiAWBuildVersionRequestModel model);

                ApiAWBuildVersionResponseModel MapBOToModel(
                        BOAWBuildVersion boAWBuildVersion);

                List<ApiAWBuildVersionResponseModel> MapBOToModel(
                        List<BOAWBuildVersion> items);
        }
}

/*<Codenesium>
    <Hash>03515fdd0c6d995f084e8c76f6d6727e</Hash>
</Codenesium>*/