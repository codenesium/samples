using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALEmployeeDepartmentHistoryMapper
        {
                EmployeeDepartmentHistory MapBOToEF(
                        BOEmployeeDepartmentHistory bo);

                BOEmployeeDepartmentHistory MapEFToBO(
                        EmployeeDepartmentHistory efEmployeeDepartmentHistory);

                List<BOEmployeeDepartmentHistory> MapEFToBO(
                        List<EmployeeDepartmentHistory> records);
        }
}

/*<Codenesium>
    <Hash>810915703eb47c0b0fdcd2464b3bfa07</Hash>
</Codenesium>*/