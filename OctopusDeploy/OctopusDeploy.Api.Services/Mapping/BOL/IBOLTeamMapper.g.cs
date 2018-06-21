using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLTeamMapper
        {
                BOTeam MapModelToBO(
                        string id,
                        ApiTeamRequestModel model);

                ApiTeamResponseModel MapBOToModel(
                        BOTeam boTeam);

                List<ApiTeamResponseModel> MapBOToModel(
                        List<BOTeam> items);
        }
}

/*<Codenesium>
    <Hash>db0c63b0ad009031d7eab7653a9a4371</Hash>
</Codenesium>*/