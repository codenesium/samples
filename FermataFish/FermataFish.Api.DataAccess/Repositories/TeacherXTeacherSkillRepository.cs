using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class TeacherXTeacherSkillRepository: AbstractTeacherXTeacherSkillRepository, ITeacherXTeacherSkillRepository
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
    <Hash>69f53a728a4d43f592fc23350f3c14ec</Hash>
</Codenesium>*/