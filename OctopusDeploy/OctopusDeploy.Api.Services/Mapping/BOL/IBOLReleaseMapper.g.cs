using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>2e248c42e78d7bd6e0c4d2e98a924dfe</Hash>
</Codenesium>*/