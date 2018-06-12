using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>1294e45e6368dc1d4e4ea3fd83fb7c7d</Hash>
</Codenesium>*/