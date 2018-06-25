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
        public partial class LessonXStudentService : AbstractLessonXStudentService, ILessonXStudentService
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
    <Hash>9fa2fd1bfa20f15c0dbed050dc08e848</Hash>
</Codenesium>*/