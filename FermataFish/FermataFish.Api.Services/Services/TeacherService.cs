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
        public class TeacherService : AbstractTeacherService, ITeacherService
        {
                public TeacherService(
                        ILogger<ITeacherRepository> logger,
                        ITeacherRepository teacherRepository,
                        IApiTeacherRequestModelValidator teacherModelValidator,
                        IBOLTeacherMapper bolteacherMapper,
                        IDALTeacherMapper dalteacherMapper,
                        IBOLRateMapper bolRateMapper,
                        IDALRateMapper dalRateMapper,
                        IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper,
                        IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper
                        )
                        : base(logger,
                               teacherRepository,
                               teacherModelValidator,
                               bolteacherMapper,
                               dalteacherMapper,
                               bolRateMapper,
                               dalRateMapper,
                               bolTeacherXTeacherSkillMapper,
                               dalTeacherXTeacherSkillMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>1badd7de3b4af82c8f81e81eeb935c47</Hash>
</Codenesium>*/