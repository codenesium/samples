using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>87f9d2ee43688dac254998f7f2a78a8c</Hash>
</Codenesium>*/