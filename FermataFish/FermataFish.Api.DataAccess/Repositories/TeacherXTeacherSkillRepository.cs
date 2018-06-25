using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public partial class TeacherXTeacherSkillRepository : AbstractTeacherXTeacherSkillRepository, ITeacherXTeacherSkillRepository
        {
                public TeacherXTeacherSkillRepository(
                        ILogger<TeacherXTeacherSkillRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2db45d264c6238d9b9a4b6dce4992324</Hash>
</Codenesium>*/