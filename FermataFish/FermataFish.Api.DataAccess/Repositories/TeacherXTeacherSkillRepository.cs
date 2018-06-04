using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class TeacherXTeacherSkillRepository: AbstractTeacherXTeacherSkillRepository, ITeacherXTeacherSkillRepository
	{
		public TeacherXTeacherSkillRepository(
			ILogger<TeacherXTeacherSkillRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>d95e8b9178bf8b7236b6b6594af10417</Hash>
</Codenesium>*/