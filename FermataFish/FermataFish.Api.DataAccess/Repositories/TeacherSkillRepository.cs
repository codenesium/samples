using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class TeacherSkillRepository: AbstractTeacherSkillRepository, ITeacherSkillRepository
	{
		public TeacherSkillRepository(
			ILogger<TeacherSkillRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>5f7a731c49ca156577096b72de90293a</Hash>
</Codenesium>*/