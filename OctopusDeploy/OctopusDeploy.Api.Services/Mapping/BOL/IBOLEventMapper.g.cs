using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLEventMapper
        {
                BOEvent MapModelToBO(
                        string id,
                        ApiEventRequestModel model);

                ApiEventResponseModel MapBOToModel(
                        BOEvent boEvent);

                List<ApiEventResponseModel> MapBOToModel(
                        List<BOEvent> items);
        }
}

/*<Codenesium>
    <Hash>2087e2de4f39ff5ea8d629434bb325d5</Hash>
</Codenesium>*/