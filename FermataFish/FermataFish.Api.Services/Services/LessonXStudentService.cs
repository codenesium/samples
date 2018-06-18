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
                               dallessonXStudentMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>18db6d029bda940becbb2286844be942</Hash>
</Codenesium>*/