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
        public class LessonService: AbstractLessonService, ILessonService
        {
                public LessonService(
                        ILogger<LessonRepository> logger,
                        ILessonRepository lessonRepository,
                        IApiLessonRequestModelValidator lessonModelValidator,
                        IBOLLessonMapper bollessonMapper,
                        IDALLessonMapper dallessonMapper)
                        : base(logger,
                               lessonRepository,
                               lessonModelValidator,
                               bollessonMapper,
                               dallessonMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4051cdea5c5529a021430857df864494</Hash>
</Codenesium>*/