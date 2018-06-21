using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALBusinessEntityContactMapper
        {
                BusinessEntityContact MapBOToEF(
                        BOBusinessEntityContact bo);

                BOBusinessEntityContact MapEFToBO(
                        BusinessEntityContact efBusinessEntityContact);

                List<BOBusinessEntityContact> MapEFToBO(
                        List<BusinessEntityContact> records);
        }
}

/*<Codenesium>
    <Hash>037c60655030c3be6ba1339fecb8ac08</Hash>
</Codenesium>*/