using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALShiftMapper
        {
                Shift MapBOToEF(
                        BOShift bo);

                BOShift MapEFToBO(
                        Shift efShift);

                List<BOShift> MapEFToBO(
                        List<Shift> records);
        }
}

/*<Codenesium>
    <Hash>2374e8ffafc579bbde60a8b7595b9550</Hash>
</Codenesium>*/