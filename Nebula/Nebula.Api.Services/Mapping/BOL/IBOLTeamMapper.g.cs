using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>8b92a38353370cf494438fadc161b499</Hash>
</Codenesium>*/