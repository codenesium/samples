using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IDALLessonXTeacherMapper
        {
                LessonXTeacher MapBOToEF(
                        BOLessonXTeacher bo);

                BOLessonXTeacher MapEFToBO(
                        LessonXTeacher efLessonXTeacher);

                List<BOLessonXTeacher> MapEFToBO(
                        List<LessonXTeacher> records);
        }
}

/*<Codenesium>
    <Hash>042c6ac161b76edb77b349e17056c2f1</Hash>
</Codenesium>*/