using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>88905680d9fb53a2e236c5ac5807ba22</Hash>
</Codenesium>*/