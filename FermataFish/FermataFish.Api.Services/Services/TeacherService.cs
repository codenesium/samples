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
        public partial class TeacherService : AbstractTeacherService, ITeacherService
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
    <Hash>a68a30cdb1b455e32375e87d8ba3c9f3</Hash>
</Codenesium>*/