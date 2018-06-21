using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>9ca5f255e24f4982fc6dd28a46162f23</Hash>
</Codenesium>*/