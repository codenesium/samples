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
	public partial class TeacherSkillRepository : AbstractTeacherSkillRepository, ITeacherSkillRepository
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
    <Hash>b72d2621a49d81ba051ad3e266d72828</Hash>
</Codenesium>*/