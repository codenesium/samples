using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IDALRateMapper
        {
                Rate MapBOToEF(
                        BORate bo);

                BORate MapEFToBO(
                        Rate efRate);

                List<BORate> MapEFToBO(
                        List<Rate> records);
        }
}

/*<Codenesium>
    <Hash>d6124f959ef2fb25bbdd10c0031a49ea</Hash>
</Codenesium>*/