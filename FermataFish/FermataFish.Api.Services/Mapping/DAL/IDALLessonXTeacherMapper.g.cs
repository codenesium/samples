using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>dc83a4da58d17db3f77cd985ec6bf105</Hash>
</Codenesium>*/