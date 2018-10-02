using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
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
    <Hash>8586dcca62d1859fd319dcc194044e23</Hash>
</Codenesium>*/