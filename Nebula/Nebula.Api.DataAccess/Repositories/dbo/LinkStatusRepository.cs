using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public class LinkStatusRepository: AbstractLinkStatusRepository, ILinkStatusRepository
	{
		public LinkStatusRepository(ILogger<LinkStatusRepository> logger,
		                            ApplicationContext context) : base(logger,context)
		{}

		protected override List<LinkStatus> SearchLinqEF(Expression<Func<LinkStatus, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<LinkStatus>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<LinkStatus>();
			}
			else
			{
				return this._context.Set<LinkStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LinkStatus>();
			}
		}

		protected override List<LinkStatus> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<LinkStatus>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<LinkStatus>();
			}
			else
			{
				return this._context.Set<LinkStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LinkStatus>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>d7d9d6761e3e124a69ccfaa03d678e88</Hash>
</Codenesium>*/