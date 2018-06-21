using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLServerTaskMapper
        {
                BOServerTask MapModelToBO(
                        string id,
                        ApiServerTaskRequestModel model);

                ApiServerTaskResponseModel MapBOToModel(
                        BOServerTask boServerTask);

                List<ApiServerTaskResponseModel> MapBOToModel(
                        List<BOServerTask> items);
        }
}

/*<Codenesium>
    <Hash>afa5e3f793d4e81bbe18edaa2a44edbe</Hash>
</Codenesium>*/