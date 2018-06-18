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
        public class LessonXTeacherService: AbstractLessonXTeacherService, ILessonXTeacherService
        {
                public LessonXTeacherService(
                        ILogger<ILessonXTeacherRepository> logger,
                        ILessonXTeacherRepository lessonXTeacherRepository,
                        IApiLessonXTeacherRequestModelValidator lessonXTeacherModelValidator,
                        IBOLLessonXTeacherMapper bollessonXTeacherMapper,
                        IDALLessonXTeacherMapper dallessonXTeacherMapper

                        )
                        : base(logger,
                               lessonXTeacherRepository,
                               lessonXTeacherModelValidator,
                               bollessonXTeacherMapper,
                               dallessonXTeacherMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>ce82c12e74cd1fb7fcd9ee9eae669014</Hash>
</Codenesium>*/