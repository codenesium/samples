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
                        ILogger<ILessonRepository> logger,
                        ILessonRepository lessonRepository,
                        IApiLessonRequestModelValidator lessonModelValidator,
                        IBOLLessonMapper bollessonMapper,
                        IDALLessonMapper dallessonMapper
                        ,
                        IBOLLessonXStudentMapper bolLessonXStudentMapper,
                        IDALLessonXStudentMapper dalLessonXStudentMapper
                        ,
                        IBOLLessonXTeacherMapper bolLessonXTeacherMapper,
                        IDALLessonXTeacherMapper dalLessonXTeacherMapper

                        )
                        : base(logger,
                               lessonRepository,
                               lessonModelValidator,
                               bollessonMapper,
                               dallessonMapper
                               ,
                               bolLessonXStudentMapper,
                               dalLessonXStudentMapper
                               ,
                               bolLessonXTeacherMapper,
                               dalLessonXTeacherMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>a67119a30495c734a88dc49d6156a315</Hash>
</Codenesium>*/