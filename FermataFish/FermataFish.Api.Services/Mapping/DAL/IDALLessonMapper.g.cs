using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IDALLessonMapper
        {
                Lesson MapBOToEF(
                        BOLesson bo);

                BOLesson MapEFToBO(
                        Lesson efLesson);

                List<BOLesson> MapEFToBO(
                        List<Lesson> records);
        }
}

/*<Codenesium>
    <Hash>c3bccd9d83434155f8a4155de5c8f545</Hash>
</Codenesium>*/