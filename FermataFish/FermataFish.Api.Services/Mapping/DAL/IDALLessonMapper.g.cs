using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>37a7389e6188575d7d0b4d5dd8d797e1</Hash>
</Codenesium>*/