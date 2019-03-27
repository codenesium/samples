using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial class TeacherTeacherSkillRepository : AbstractTeacherTeacherSkillRepository, ITeacherTeacherSkillRepository
	{
		public TeacherTeacherSkillRepository(
			ILogger<TeacherTeacherSkillRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b1935ffc28e2cab7ffd13a24f17340fa</Hash>
</Codenesium>*/