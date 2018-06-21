using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>1c359511aab3439b3c1382112f850c5b</Hash>
</Codenesium>*/