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
        public class TeacherService: AbstractTeacherService, ITeacherService
        {
                public TeacherService(
                        ILogger<TeacherRepository> logger,
                        ITeacherRepository teacherRepository,
                        IApiTeacherRequestModelValidator teacherModelValidator,
                        IBOLTeacherMapper bolteacherMapper,
                        IDALTeacherMapper dalteacherMapper
                        ,
                        IBOLRateMapper bolRateMapper,
                        IDALRateMapper dalRateMapper
                        ,
                        IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper,
                        IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper

                        )
                        : base(logger,
                               teacherRepository,
                               teacherModelValidator,
                               bolteacherMapper,
                               dalteacherMapper
                               ,
                               bolRateMapper,
                               dalRateMapper
                               ,
                               bolTeacherXTeacherSkillMapper,
                               dalTeacherXTeacherSkillMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>f0844f3c6a335a9ce5f6c0438bc619a0</Hash>
</Codenesium>*/