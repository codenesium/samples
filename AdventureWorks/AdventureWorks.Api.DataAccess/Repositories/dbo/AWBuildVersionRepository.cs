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
		public AWBuildVersionRepository(ILogger<AWBuildVersionRepository> logger,
		                                ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFAWBuildVersion> SearchLinqEF(Expression<Func<EFAWBuildVersion, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFAWBuildVersion>().Where(predicate).AsQueryable().OrderBy("systemInformationID ASC").Skip(skip).Take(take).ToList<EFAWBuildVersion>();
			}
			else
			{
				return this._context.Set<EFAWBuildVersion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAWBuildVersion>();
			}
		}

		protected override List<EFAWBuildVersion> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFAWBuildVersion>().Where(predicate).AsQueryable().OrderBy("systemInformationID ASC").Skip(skip).Take(take).ToList<EFAWBuildVersion>();
			}
			else
			{
				return this._context.Set<EFAWBuildVersion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAWBuildVersion>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>4a762556c9d910b3d5b24c4effc9d58c</Hash>
</Codenesium>*/