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
	public class LinkLogRepository: AbstractLinkLogRepository
	{
		public LinkLogRepository(ILogger<LinkLogRepository> logger,
		                         ApplicationContext context) : base(logger,context)
		{}

		protected override List<LinkLog> SearchLinqEF(Expression<Func<LinkLog, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<LinkLog>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<LinkLog>();
			}
			else
			{
				return this._context.Set<LinkLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LinkLog>();
			}
		}

		protected override List<LinkLog> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<LinkLog>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<LinkLog>();
			}
			else
			{
				return this._context.Set<LinkLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LinkLog>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>86816a69af97cac5f419c826bdb98aae</Hash>
</Codenesium>*/