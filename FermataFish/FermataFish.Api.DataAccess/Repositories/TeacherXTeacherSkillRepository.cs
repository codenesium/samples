using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class TeacherXTeacherSkillRepository : AbstractTeacherXTeacherSkillRepository, ITeacherXTeacherSkillRepository
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
    <Hash>274ac8440051a2c9351fd11d2e4e892d</Hash>
</Codenesium>*/