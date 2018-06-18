using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class LessonStatusService: AbstractLessonStatusService, ILessonStatusService
        {
                public LessonStatusService(
                        ILogger<ILessonStatusRepository> logger,
                        ILessonStatusRepository lessonStatusRepository,
                        IApiLessonStatusRequestModelValidator lessonStatusModelValidator,
                        IBOLLessonStatusMapper bollessonStatusMapper,
                        IDALLessonStatusMapper dallessonStatusMapper
                        ,
                        IBOLLessonMapper bolLessonMapper,
                        IDALLessonMapper dalLessonMapper

                        )
                        : base(logger,
                               lessonStatusRepository,
                               lessonStatusModelValidator,
                               bollessonStatusMapper,
                               dallessonStatusMapper
                               ,
                               bolLessonMapper,
                               dalLessonMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>12737a83c19df51f76c39ab47d4de51b</Hash>
</Codenesium>*/