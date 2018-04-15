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
	public class LessonRepository: AbstractLessonRepository, ILessonRepository
	{
		public LessonRepository(
			IObjectMapper mapper,
			ILogger<LessonRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFLesson> SearchLinqEF(Expression<Func<EFLesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFLesson>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFLesson>();
			}
			else
			{
				return this.context.Set<EFLesson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLesson>();
			}
		}

		protected override List<EFLesson> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFLesson>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFLesson>();
			}
			else
			{
				return this.context.Set<EFLesson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLesson>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>19cfc0b1eda25ae6ce40dc64c48e5dc5</Hash>
</Codenesium>*/