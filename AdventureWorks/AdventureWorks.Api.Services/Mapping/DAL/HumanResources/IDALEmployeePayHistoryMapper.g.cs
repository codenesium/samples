using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALEmployeePayHistoryMapper
        {
                EmployeePayHistory MapBOToEF(
                        BOEmployeePayHistory bo);

                BOEmployeePayHistory MapEFToBO(
                        EmployeePayHistory efEmployeePayHistory);

                List<BOEmployeePayHistory> MapEFToBO(
                        List<EmployeePayHistory> records);
        }
}

/*<Codenesium>
    <Hash>47e4abe414d7f602cdd82dd018b1c88d</Hash>
</Codenesium>*/