using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>531084163f81b0a7aa0fc3ffaf059500</Hash>
</Codenesium>*/