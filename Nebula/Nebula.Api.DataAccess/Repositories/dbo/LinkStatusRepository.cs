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
				return this._context.Set<EFLinkStatus>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFLinkStatus>();
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
				return this._context.Set<EFLinkStatus>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFLinkStatus>();
			}
			else
			{
				return this._context.Set<EFLinkStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLinkStatus>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>e184e02c2f18ee38e0d018c21ccf7e57</Hash>
</Codenesium>*/