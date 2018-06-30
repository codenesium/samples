using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLUserMapper
        {
                BOUser MapModelToBO(
                        string id,
                        ApiUserRequestModel model);

                ApiUserResponseModel MapBOToModel(
                        BOUser boUser);

                List<ApiUserResponseModel> MapBOToModel(
                        List<BOUser> items);
        }
}

/*<Codenesium>
    <Hash>277ecaf3eedb13a384b1e94f12fe0540</Hash>
</Codenesium>*/