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
    <Hash>e80503decce6b799ebd47ba7558e2935</Hash>
</Codenesium>*/