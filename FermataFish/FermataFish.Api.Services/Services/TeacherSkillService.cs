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
        public partial class TeacherSkillService : AbstractTeacherSkillService, ITeacherSkillService
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
    <Hash>fc11e9fe20ed484ee5568713a9fba89e</Hash>
</Codenesium>*/