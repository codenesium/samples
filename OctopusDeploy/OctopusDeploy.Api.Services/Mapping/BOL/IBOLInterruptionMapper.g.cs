using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLInterruptionMapper
        {
                BOInterruption MapModelToBO(
                        string id,
                        ApiInterruptionRequestModel model);

                ApiInterruptionResponseModel MapBOToModel(
                        BOInterruption boInterruption);

                List<ApiInterruptionResponseModel> MapBOToModel(
                        List<BOInterruption> items);
        }
}

/*<Codenesium>
    <Hash>a4a4225a193cae2550abdb416e197887</Hash>
</Codenesium>*/