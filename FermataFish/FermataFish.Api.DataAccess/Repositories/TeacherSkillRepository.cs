using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class TeacherSkillRepository: AbstractTeacherSkillRepository, ITeacherSkillRepository
        {
                public TeacherSkillRepository(
                        ILogger<TeacherSkillRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>74dd1110615ebbc9950d34e257a5162f</Hash>
</Codenesium>*/