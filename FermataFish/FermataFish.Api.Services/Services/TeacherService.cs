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
    <Hash>b18526b4ed6098489fd4de64de9c78c7</Hash>
</Codenesium>*/