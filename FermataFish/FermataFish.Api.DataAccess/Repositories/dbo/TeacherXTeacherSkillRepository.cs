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
			ILogger<TeacherXTeacherSkillRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
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
    <Hash>fd1fe102351202fe7c445fa362dd65e1</Hash>
</Codenesium>*/