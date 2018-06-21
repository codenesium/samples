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
        public class LessonXTeacherService : AbstractLessonXTeacherService, ILessonXTeacherService
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
    <Hash>c2ad1601fb60dc7b0722dd98edcabf8c</Hash>
</Codenesium>*/