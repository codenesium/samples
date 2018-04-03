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
	public class PersonRepository: AbstractPersonRepository, IPersonRepository
	{
		public PersonRepository(ILogger<PersonRepository> logger,
		                        ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFPerson> SearchLinqEF(Expression<Func<EFPerson, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFPerson>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFPerson>();
			}
			else
			{
				return this._context.Set<EFPerson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPerson>();
			}
		}

		protected override List<EFPerson> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFPerson>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFPerson>();
			}
			else
			{
				return this._context.Set<EFPerson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPerson>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>fcd5ba331b532297571871a2b04a9470</Hash>
</Codenesium>*/