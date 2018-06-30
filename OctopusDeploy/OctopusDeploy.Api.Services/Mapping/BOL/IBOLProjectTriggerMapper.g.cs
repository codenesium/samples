using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>00322d2592772961d2d5f5bb94584992</Hash>
</Codenesium>*/