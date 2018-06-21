using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>3e865fe12a978917bbc6260a3cad1cb2</Hash>
</Codenesium>*/