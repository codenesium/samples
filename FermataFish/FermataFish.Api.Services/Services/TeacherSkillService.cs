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
        public class TeacherSkillService : AbstractTeacherSkillService, ITeacherSkillService
        {
                public TeacherSkillService(
                        ILogger<ITeacherSkillRepository> logger,
                        ITeacherSkillRepository teacherSkillRepository,
                        IApiTeacherSkillRequestModelValidator teacherSkillModelValidator,
                        IBOLTeacherSkillMapper bolteacherSkillMapper,
                        IDALTeacherSkillMapper dalteacherSkillMapper,
                        IBOLRateMapper bolRateMapper,
                        IDALRateMapper dalRateMapper,
                        IBOLTeacherXTeacherSkillMapper bolTeacherXTeacherSkillMapper,
                        IDALTeacherXTeacherSkillMapper dalTeacherXTeacherSkillMapper
                        )
                        : base(logger,
                               teacherSkillRepository,
                               teacherSkillModelValidator,
                               bolteacherSkillMapper,
                               dalteacherSkillMapper,
                               bolRateMapper,
                               dalRateMapper,
                               bolTeacherXTeacherSkillMapper,
                               dalTeacherXTeacherSkillMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e9c7ee6baa18c179e3a77e7351156451</Hash>
</Codenesium>*/