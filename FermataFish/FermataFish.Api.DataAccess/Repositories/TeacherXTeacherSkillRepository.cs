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
    <Hash>e8a0f93c2e6f0d5c2b068d187a0f9bbd</Hash>
</Codenesium>*/