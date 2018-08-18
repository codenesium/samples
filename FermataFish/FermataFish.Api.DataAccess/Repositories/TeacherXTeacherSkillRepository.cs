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
    <Hash>1ef85e11d563482a0c60d0d784feb5d6</Hash>
</Codenesium>*/