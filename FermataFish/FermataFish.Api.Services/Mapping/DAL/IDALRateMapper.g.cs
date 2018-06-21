using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>11fb21ca15a303a897f3ea79e613912e</Hash>
</Codenesium>*/