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
                        IDALLessonStatusMapper dallessonStatusMapper)
                        : base(logger,
                               lessonStatusRepository,
                               lessonStatusModelValidator,
                               bollessonStatusMapper,
                               dallessonStatusMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d248c3ea470b528b21d743bec6c15534</Hash>
</Codenesium>*/