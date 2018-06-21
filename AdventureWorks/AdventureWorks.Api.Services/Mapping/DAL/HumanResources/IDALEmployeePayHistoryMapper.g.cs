using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>384ba99615bc753b8d5348b3c32b5d05</Hash>
</Codenesium>*/