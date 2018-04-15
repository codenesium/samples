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
			IObjectMapper mapper,
			ILogger<TeacherXTeacherSkillRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFTeacherXTeacherSkill> SearchLinqEF(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFTeacherXTeacherSkill>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFTeacherXTeacherSkill>();
			}
			else
			{
				return this.context.Set<EFTeacherXTeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTeacherXTeacherSkill>();
			}
		}

		protected override List<EFTeacherXTeacherSkill> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFTeacherXTeacherSkill>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFTeacherXTeacherSkill>();
			}
			else
			{
				return this.context.Set<EFTeacherXTeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTeacherXTeacherSkill>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>eefdae91bfd8dfaa485c9e5c8b8c8e5d</Hash>
</Codenesium>*/