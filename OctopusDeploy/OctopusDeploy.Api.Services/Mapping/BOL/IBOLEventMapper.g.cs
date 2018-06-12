using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>b411a9b091dec18071d17fd8a29e4fb5</Hash>
</Codenesium>*/