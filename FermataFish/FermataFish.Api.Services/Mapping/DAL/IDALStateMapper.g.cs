using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IDALStateMapper
        {
                State MapBOToEF(
                        BOState bo);

                BOState MapEFToBO(
                        State efState);

                List<BOState> MapEFToBO(
                        List<State> records);
        }
}

/*<Codenesium>
    <Hash>b007b57e605919176eeb738db3cf4447</Hash>
</Codenesium>*/