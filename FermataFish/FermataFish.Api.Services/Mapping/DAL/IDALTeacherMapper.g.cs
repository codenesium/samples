using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>88e01914785edae11026104759e87880</Hash>
</Codenesium>*/