using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>a661ff3cbf5a0187816bcd6b6b2c587b</Hash>
</Codenesium>*/