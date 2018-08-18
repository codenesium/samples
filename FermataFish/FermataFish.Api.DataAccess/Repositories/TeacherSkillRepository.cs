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
    <Hash>42531b8f2ce914873073f7a8ea828e80</Hash>
</Codenesium>*/