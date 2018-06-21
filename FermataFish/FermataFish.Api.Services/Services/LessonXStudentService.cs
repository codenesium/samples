using Codenesium.DataConversionExtensions;
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
        public class LessonXStudentService : AbstractLessonXStudentService, ILessonXStudentService
        {
                public LessonXStudentService(
                        ILogger<ILessonXStudentRepository> logger,
                        ILessonXStudentRepository lessonXStudentRepository,
                        IApiLessonXStudentRequestModelValidator lessonXStudentModelValidator,
                        IBOLLessonXStudentMapper bollessonXStudentMapper,
                        IDALLessonXStudentMapper dallessonXStudentMapper
                        )
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
    <Hash>108ebc070d9708fc0f439d7c5d8670a8</Hash>
</Codenesium>*/