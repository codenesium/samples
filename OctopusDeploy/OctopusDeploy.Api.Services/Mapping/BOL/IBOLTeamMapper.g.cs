using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>51990abfd75def95454b95c6e4921ebf</Hash>
</Codenesium>*/