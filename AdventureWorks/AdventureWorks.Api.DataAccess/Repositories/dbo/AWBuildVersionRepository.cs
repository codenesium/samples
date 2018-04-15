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
	public class AWBuildVersionRepository: AbstractAWBuildVersionRepository, IAWBuildVersionRepository
	{
		public AWBuildVersionRepository(
			IObjectMapper mapper,
			ILogger<AWBuildVersionRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFAWBuildVersion> SearchLinqEF(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFAWBuildVersion>().Where(predicate).AsQueryable().OrderBy("SystemInformationID ASC").Skip(skip).Take(take).ToList<EFAWBuildVersion>();
			}
			else
			{
				return this.context.Set<EFAWBuildVersion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAWBuildVersion>();
			}
		}

		protected override List<EFAWBuildVersion> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFAWBuildVersion>().Where(predicate).AsQueryable().OrderBy("SystemInformationID ASC").Skip(skip).Take(take).ToList<EFAWBuildVersion>();
			}
			else
			{
				return this.context.Set<EFAWBuildVersion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAWBuildVersion>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>d0801f02fe58efc41afca9a8ec2e45a0</Hash>
</Codenesium>*/