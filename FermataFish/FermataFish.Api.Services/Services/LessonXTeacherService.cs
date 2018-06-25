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
        public partial class LessonXTeacherService : AbstractLessonXTeacherService, ILessonXTeacherService
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
                               dallessonXTeacherMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>695ff91e221f1bd34a4649bd3e700011</Hash>
</Codenesium>*/