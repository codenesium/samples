using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALStateProvinceMapper
        {
                StateProvince MapBOToEF(
                        BOStateProvince bo);

                BOStateProvince MapEFToBO(
                        StateProvince efStateProvince);

                List<BOStateProvince> MapEFToBO(
                        List<StateProvince> records);
        }
}

/*<Codenesium>
    <Hash>9f66421fe50c0ff49cb0d5d1dac2581f</Hash>
</Codenesium>*/