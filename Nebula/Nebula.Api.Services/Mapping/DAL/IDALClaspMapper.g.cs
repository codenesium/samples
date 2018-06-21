using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>8eaba12f8cfcb91e469189c6c334f165</Hash>
</Codenesium>*/