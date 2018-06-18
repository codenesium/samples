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
        public class TeacherXTeacherSkillService: AbstractTeacherXTeacherSkillService, ITeacherXTeacherSkillService
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
                               dalteacherXTeacherSkillMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>477883196e150b027f93bc60b5522bb1</Hash>
</Codenesium>*/