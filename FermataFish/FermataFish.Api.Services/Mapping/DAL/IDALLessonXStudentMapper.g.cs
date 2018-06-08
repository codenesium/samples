using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>840bdbef6147d3dd28dfda642398788e</Hash>
</Codenesium>*/