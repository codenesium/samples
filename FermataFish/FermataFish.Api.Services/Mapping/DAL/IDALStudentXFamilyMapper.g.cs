using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IDALStudentXFamilyMapper
        {
                StudentXFamily MapBOToEF(
                        BOStudentXFamily bo);

                BOStudentXFamily MapEFToBO(
                        StudentXFamily efStudentXFamily);

                List<BOStudentXFamily> MapEFToBO(
                        List<StudentXFamily> records);
        }
}

/*<Codenesium>
    <Hash>0cf169dc0c69e720a9d515816d6afd2b</Hash>
</Codenesium>*/