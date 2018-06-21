using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IDALLessonXStudentMapper
        {
                LessonXStudent MapBOToEF(
                        BOLessonXStudent bo);

                BOLessonXStudent MapEFToBO(
                        LessonXStudent efLessonXStudent);

                List<BOLessonXStudent> MapEFToBO(
                        List<LessonXStudent> records);
        }
}

/*<Codenesium>
    <Hash>05c6a080ae3c6a96b9685ac3b2db00e7</Hash>
</Codenesium>*/