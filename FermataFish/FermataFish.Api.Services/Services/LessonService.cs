using Codenesium.DataConversionExtensions.AspNetCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Services
{
        public class LessonService : AbstractLessonService, ILessonService
        {
                public LessonService(
                        ILogger<ILessonRepository> logger,
                        ILessonRepository lessonRepository,
                        IApiLessonRequestModelValidator lessonModelValidator,
                        IBOLLessonMapper bollessonMapper,
                        IDALLessonMapper dallessonMapper,
                        IBOLLessonXStudentMapper bolLessonXStudentMapper,
                        IDALLessonXStudentMapper dalLessonXStudentMapper,
                        IBOLLessonXTeacherMapper bolLessonXTeacherMapper,
                        IDALLessonXTeacherMapper dalLessonXTeacherMapper
                        )
                        : base(logger,
                               lessonRepository,
                               lessonModelValidator,
                               bollessonMapper,
                               dallessonMapper,
                               bolLessonXStudentMapper,
                               dalLessonXStudentMapper,
                               bolLessonXTeacherMapper,
                               dalLessonXTeacherMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>64ac3e83f6673459d21e268e266c1fe6</Hash>
</Codenesium>*/