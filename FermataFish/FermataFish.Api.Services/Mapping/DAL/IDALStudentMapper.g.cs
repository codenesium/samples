using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IDALStudentMapper
        {
                Student MapBOToEF(
                        BOStudent bo);

                BOStudent MapEFToBO(
                        Student efStudent);

                List<BOStudent> MapEFToBO(
                        List<Student> records);
        }
}

/*<Codenesium>
    <Hash>cd51ff429f9b4ed4a8aa7c2b3642faaf</Hash>
</Codenesium>*/