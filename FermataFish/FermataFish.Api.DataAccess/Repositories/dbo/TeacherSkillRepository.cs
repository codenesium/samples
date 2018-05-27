using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public class TeacherSkillRepository: AbstractTeacherSkillRepository, ITeacherSkillRepository
	{
		public TeacherSkillRepository(
			IDALTeacherSkillMapper mapper,
			ILogger<TeacherSkillRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>dbf0e1d8048912d7e60da915bb4fce80</Hash>
</Codenesium>*/