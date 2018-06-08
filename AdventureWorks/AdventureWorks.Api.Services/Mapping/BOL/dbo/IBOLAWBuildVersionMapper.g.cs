using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>3e3765ba80c1637b93f174f28aed0fac</Hash>
</Codenesium>*/