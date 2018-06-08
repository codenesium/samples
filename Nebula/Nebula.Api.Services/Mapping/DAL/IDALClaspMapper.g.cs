using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface IDALClaspMapper
        {
                Clasp MapBOToEF(
                        BOClasp bo);

                BOClasp MapEFToBO(
                        Clasp efClasp);

                List<BOClasp> MapEFToBO(
                        List<Clasp> records);
        }
}

/*<Codenesium>
    <Hash>996c2d1c00733e4a1e971c04756e2e4a</Hash>
</Codenesium>*/