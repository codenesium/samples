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

		protected override List<EFLinkStatus> SearchLinqEF(Expression<Func<EFLinkStatus, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFLinkStatus>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFLinkStatus>();
			}
			else
			{
				return this._context.Set<EFLinkStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLinkStatus>();
			}
		}

		protected override List<EFLinkStatus> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFLinkStatus>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFLinkStatus>();
			}
			else
			{
				return this._context.Set<EFLinkStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLinkStatus>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>5f3b5989615d79502113fa092ceae2b0</Hash>
</Codenesium>*/