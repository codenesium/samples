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
			ILogger<LessonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
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
    <Hash>61b3453f781703f781f4f3a96483dc0f</Hash>
</Codenesium>*/