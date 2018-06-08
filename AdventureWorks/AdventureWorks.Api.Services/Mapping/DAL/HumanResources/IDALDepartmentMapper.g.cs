using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALDepartmentMapper
        {
                Department MapBOToEF(
                        BODepartment bo);

                BODepartment MapEFToBO(
                        Department efDepartment);

                List<BODepartment> MapEFToBO(
                        List<Department> records);
        }
}

/*<Codenesium>
    <Hash>c97139f9073319877b3213fe5cbe51bd</Hash>
</Codenesium>*/