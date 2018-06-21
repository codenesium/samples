using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>08a74742121014c447d2e78149cc1391</Hash>
</Codenesium>*/