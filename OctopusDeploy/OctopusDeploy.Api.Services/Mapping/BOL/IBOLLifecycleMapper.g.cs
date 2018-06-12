using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLLifecycleMapper
        {
                BOLifecycle MapModelToBO(
                        string id,
                        ApiLifecycleRequestModel model);

                ApiLifecycleResponseModel MapBOToModel(
                        BOLifecycle boLifecycle);

                List<ApiLifecycleResponseModel> MapBOToModel(
                        List<BOLifecycle> items);
        }
}

/*<Codenesium>
    <Hash>4a1131e4387efb710a1de4847a548f7c</Hash>
</Codenesium>*/