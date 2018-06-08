using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>02baa142eade2e0ff242a4c5b97b3a79</Hash>
</Codenesium>*/