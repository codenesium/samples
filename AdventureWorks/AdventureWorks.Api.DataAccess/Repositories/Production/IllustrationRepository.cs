using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class IllustrationRepository: AbstractIllustrationRepository, IIllustrationRepository
	{
		public IllustrationRepository(
			ILogger<IllustrationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}

		protected override List<EFIllustration> SearchLinqEF(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFIllustration>().Where(predicate).AsQueryable().OrderBy("IllustrationID ASC").Skip(skip).Take(take).ToList<EFIllustration>();
			}
			else
			{
				return this.context.Set<EFIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFIllustration>();
			}
		}

		protected override List<EFIllustration> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFIllustration>().Where(predicate).AsQueryable().OrderBy("IllustrationID ASC").Skip(skip).Take(take).ToList<EFIllustration>();
			}
			else
			{
				return this.context.Set<EFIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFIllustration>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>e1d759fc336214bf69d46e34aef918e0</Hash>
</Codenesium>*/