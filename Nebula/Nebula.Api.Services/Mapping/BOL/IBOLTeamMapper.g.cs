using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IBOLTeamMapper
        {
                BOTeam MapModelToBO(
                        int id,
                        ApiTeamRequestModel model);

                ApiTeamResponseModel MapBOToModel(
                        BOTeam boTeam);

                List<ApiTeamResponseModel> MapBOToModel(
                        List<BOTeam> items);
        }
}

/*<Codenesium>
    <Hash>415f47c5babf0242899678dc34e03848</Hash>
</Codenesium>*/