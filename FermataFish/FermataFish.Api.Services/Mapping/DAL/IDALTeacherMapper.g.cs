using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IDALTeacherMapper
        {
                Teacher MapBOToEF(
                        BOTeacher bo);

                BOTeacher MapEFToBO(
                        Teacher efTeacher);

                List<BOTeacher> MapEFToBO(
                        List<Teacher> records);
        }
}

/*<Codenesium>
    <Hash>b3416dad02c95250fbf74edf646618a4</Hash>
</Codenesium>*/