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
		                          ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFPassword> SearchLinqEF(Expression<Func<EFPassword, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFPassword>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFPassword>();
			}
			else
			{
				return this._context.Set<EFPassword>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPassword>();
			}
		}

		protected override List<EFPassword> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFPassword>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFPassword>();
			}
			else
			{
				return this._context.Set<EFPassword>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPassword>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>9413c6edc98397655dc9069aa2da82b3</Hash>
</Codenesium>*/