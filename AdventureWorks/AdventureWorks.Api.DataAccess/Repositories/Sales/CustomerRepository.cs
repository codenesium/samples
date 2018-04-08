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
		                          ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFCustomer> SearchLinqEF(Expression<Func<EFCustomer, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFCustomer>().Where(predicate).AsQueryable().OrderBy("CustomerID ASC").Skip(skip).Take(take).ToList<EFCustomer>();
			}
			else
			{
				return this.context.Set<EFCustomer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCustomer>();
			}
		}

		protected override List<EFCustomer> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFCustomer>().Where(predicate).AsQueryable().OrderBy("CustomerID ASC").Skip(skip).Take(take).ToList<EFCustomer>();
			}
			else
			{
				return this.context.Set<EFCustomer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCustomer>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>657e07b3abbb8e2d6dae0b340df569ea</Hash>
</Codenesium>*/