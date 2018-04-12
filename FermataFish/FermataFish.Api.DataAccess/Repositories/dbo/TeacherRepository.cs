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
	public class TeacherRepository: AbstractTeacherRepository, ITeacherRepository
	{
		public TeacherRepository(
			ILogger<TeacherRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}

		protected override List<EFTeacher> SearchLinqEF(Expression<Func<EFTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFTeacher>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFTeacher>();
			}
			else
			{
				return this.context.Set<EFTeacher>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTeacher>();
			}
		}

		protected override List<EFTeacher> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFTeacher>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFTeacher>();
			}
			else
			{
				return this.context.Set<EFTeacher>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTeacher>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>3cfcb26a30047358a9ec4b119204ce49</Hash>
</Codenesium>*/