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
	public class PasswordRepository: AbstractPasswordRepository, IPasswordRepository
	{
		public PasswordRepository(ILogger<PasswordRepository> logger,
		                          ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFPassword> SearchLinqEF(Expression<Func<EFPassword, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFPassword>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFPassword>();
			}
			else
			{
				return this.context.Set<EFPassword>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPassword>();
			}
		}

		protected override List<EFPassword> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFPassword>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFPassword>();
			}
			else
			{
				return this.context.Set<EFPassword>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPassword>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>2bc83eb2a7545ff419c82a27f328ec13</Hash>
</Codenesium>*/