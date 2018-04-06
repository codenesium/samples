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
	public class CustomerRepository: AbstractCustomerRepository, ICustomerRepository
	{
		public CustomerRepository(ILogger<CustomerRepository> logger,
		                          ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFCustomer> SearchLinqEF(Expression<Func<EFCustomer, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFCustomer>().Where(predicate).AsQueryable().OrderBy("CustomerID ASC").Skip(skip).Take(take).ToList<EFCustomer>();
			}
			else
			{
				return this._context.Set<EFCustomer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCustomer>();
			}
		}

		protected override List<EFCustomer> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFCustomer>().Where(predicate).AsQueryable().OrderBy("CustomerID ASC").Skip(skip).Take(take).ToList<EFCustomer>();
			}
			else
			{
				return this._context.Set<EFCustomer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCustomer>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>201fe50b325ec33e2969b0db44e17f4d</Hash>
</Codenesium>*/