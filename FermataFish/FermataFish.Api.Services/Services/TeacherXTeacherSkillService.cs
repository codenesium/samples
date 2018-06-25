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
        public partial class TeacherXTeacherSkillService : AbstractTeacherXTeacherSkillService, ITeacherXTeacherSkillService
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
    <Hash>fda14d296305f5c6b771ea9817b2a3b8</Hash>
</Codenesium>*/