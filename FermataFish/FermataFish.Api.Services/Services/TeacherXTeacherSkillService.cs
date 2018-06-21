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
        public class TeacherXTeacherSkillService : AbstractTeacherXTeacherSkillService, ITeacherXTeacherSkillService
        {
                public TeacherXTeacherSkillService(
                        ILogger<ITeacherXTeacherSkillRepository> logger,
                        ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
                        IApiTeacherXTeacherSkillRequestModelValidator teacherXTeacherSkillModelValidator,
                        IBOLTeacherXTeacherSkillMapper bolteacherXTeacherSkillMapper,
                        IDALTeacherXTeacherSkillMapper dalteacherXTeacherSkillMapper
                        )
                        : base(logger,
                               teacherXTeacherSkillRepository,
                               teacherXTeacherSkillModelValidator,
                               bolteacherXTeacherSkillMapper,
                               dalteacherXTeacherSkillMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2e3ab5d17b8c68091f831f63cc1921b7</Hash>
</Codenesium>*/