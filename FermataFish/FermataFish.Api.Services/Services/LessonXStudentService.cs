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
        public class LessonXStudentService: AbstractLessonXStudentService, ILessonXStudentService
        {
                public LessonXStudentService(
                        ILogger<LessonXStudentRepository> logger,
                        ILessonXStudentRepository lessonXStudentRepository,
                        IApiLessonXStudentRequestModelValidator lessonXStudentModelValidator,
                        IBOLLessonXStudentMapper bollessonXStudentMapper,
                        IDALLessonXStudentMapper dallessonXStudentMapper)
                        : base(logger,
                               lessonXStudentRepository,
                               lessonXStudentModelValidator,
                               bollessonXStudentMapper,
                               dallessonXStudentMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>109ab905c97fa750776511ac135b5509</Hash>
</Codenesium>*/