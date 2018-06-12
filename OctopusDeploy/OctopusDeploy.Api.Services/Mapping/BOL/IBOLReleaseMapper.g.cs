using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLReleaseMapper
        {
                BORelease MapModelToBO(
                        string id,
                        ApiReleaseRequestModel model);

                ApiReleaseResponseModel MapBOToModel(
                        BORelease boRelease);

                List<ApiReleaseResponseModel> MapBOToModel(
                        List<BORelease> items);
        }
}

/*<Codenesium>
    <Hash>dc194e95a91e3f231ae3b848d4be45bb</Hash>
</Codenesium>*/