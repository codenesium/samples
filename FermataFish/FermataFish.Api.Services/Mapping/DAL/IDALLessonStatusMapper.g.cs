using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IDALLessonStatusMapper
        {
                LessonStatus MapBOToEF(
                        BOLessonStatus bo);

                BOLessonStatus MapEFToBO(
                        LessonStatus efLessonStatus);

                List<BOLessonStatus> MapEFToBO(
                        List<LessonStatus> records);
        }
}

/*<Codenesium>
    <Hash>574522a071566467497f93e182a455ff</Hash>
</Codenesium>*/