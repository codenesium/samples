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
	public class PersonPhoneRepository: AbstractPersonPhoneRepository, IPersonPhoneRepository
	{
		public PersonPhoneRepository(ILogger<PersonPhoneRepository> logger,
		                             ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFPersonPhone> SearchLinqEF(Expression<Func<EFPersonPhone, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFPersonPhone>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFPersonPhone>();
			}
			else
			{
				return this._context.Set<EFPersonPhone>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPersonPhone>();
			}
		}

		protected override List<EFPersonPhone> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFPersonPhone>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFPersonPhone>();
			}
			else
			{
				return this._context.Set<EFPersonPhone>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPersonPhone>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>8798851728ce174dbbdadf02e8d75891</Hash>
</Codenesium>*/