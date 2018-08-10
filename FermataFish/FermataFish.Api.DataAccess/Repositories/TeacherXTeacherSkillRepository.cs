using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>acbbdafb493415a456c428e1b352f7d4</Hash>
</Codenesium>*/