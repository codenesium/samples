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
	public class LessonXStudentRepository: AbstractLessonXStudentRepository, ILessonXStudentRepository
	{
		public LessonXStudentRepository(
			IObjectMapper mapper,
			ILogger<LessonXStudentRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFLessonXStudent> SearchLinqEF(Expression<Func<EFLessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFLessonXStudent>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFLessonXStudent>();
			}
			else
			{
				return this.context.Set<EFLessonXStudent>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLessonXStudent>();
			}
		}

		protected override List<EFLessonXStudent> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFLessonXStudent>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFLessonXStudent>();
			}
			else
			{
				return this.context.Set<EFLessonXStudent>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLessonXStudent>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>ae9e8fb74f4fd7ee60276be2b6665065</Hash>
</Codenesium>*/