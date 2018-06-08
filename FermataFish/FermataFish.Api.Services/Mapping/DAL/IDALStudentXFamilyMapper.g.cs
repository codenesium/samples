using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>02499ab488cf990c6e5fb914cd363d3c</Hash>
</Codenesium>*/