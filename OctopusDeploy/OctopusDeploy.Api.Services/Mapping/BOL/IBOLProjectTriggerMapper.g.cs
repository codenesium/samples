using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLProjectTriggerMapper
        {
                BOProjectTrigger MapModelToBO(
                        string id,
                        ApiProjectTriggerRequestModel model);

                ApiProjectTriggerResponseModel MapBOToModel(
                        BOProjectTrigger boProjectTrigger);

                List<ApiProjectTriggerResponseModel> MapBOToModel(
                        List<BOProjectTrigger> items);
        }
}

/*<Codenesium>
    <Hash>096ffd2d38dc8dcea35223673f873f5d</Hash>
</Codenesium>*/