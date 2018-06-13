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
        public class TeacherSkillService: AbstractTeacherSkillService, ITeacherSkillService
        {
                public TeacherSkillService(
                        ILogger<TeacherSkillRepository> logger,
                        ITeacherSkillRepository teacherSkillRepository,
                        IApiTeacherSkillRequestModelValidator teacherSkillModelValidator,
                        IBOLTeacherSkillMapper bolteacherSkillMapper,
                        IDALTeacherSkillMapper dalteacherSkillMapper
                        ,
                        IBOLRateMapper bolRateMapper,
                        IDALRateMapper dalRateMapper
                        ,
                        IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper,
                        IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper

                        )
                        : base(logger,
                               teacherSkillRepository,
                               teacherSkillModelValidator,
                               bolteacherSkillMapper,
                               dalteacherSkillMapper
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
    <Hash>598804d39d5648c17e4445f5c9a2ad27</Hash>
</Codenesium>*/