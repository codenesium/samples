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
	public class TeacherXTeacherSkillRepository: AbstractTeacherXTeacherSkillRepository, ITeacherXTeacherSkillRepository
	{
		public TeacherXTeacherSkillRepository(
			IDALTeacherXTeacherSkillMapper mapper,
			ILogger<TeacherXTeacherSkillRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>d3a37cfb75aa446b75393cbf27f814cf</Hash>
</Codenesium>*/