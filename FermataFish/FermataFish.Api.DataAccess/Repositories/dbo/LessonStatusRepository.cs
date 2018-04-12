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
	public class LessonStatusRepository: AbstractLessonStatusRepository, ILessonStatusRepository
	{
		public LessonStatusRepository(
			ILogger<LessonStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}

		protected override List<EFLessonStatus> SearchLinqEF(Expression<Func<EFLessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFLessonStatus>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFLessonStatus>();
			}
			else
			{
				return this.context.Set<EFLessonStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLessonStatus>();
			}
		}

		protected override List<EFLessonStatus> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFLessonStatus>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFLessonStatus>();
			}
			else
			{
				return this.context.Set<EFLessonStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLessonStatus>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>7bfa156b6ad798a043b201d5931109f5</Hash>
</Codenesium>*/