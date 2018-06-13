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
                        ILogger<LessonStatusRepository> logger,
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
    <Hash>dd2a7590cd69ae9e32b0c2f9c0e435f4</Hash>
</Codenesium>*/