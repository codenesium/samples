using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>836a7fe3272ae29ab30b5a604b9f1843</Hash>
</Codenesium>*/