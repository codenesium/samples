using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class TeacherSkillRepository : AbstractTeacherSkillRepository, ITeacherSkillRepository
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
    <Hash>625272097b02b454b8f34d9b115e3884</Hash>
</Codenesium>*/