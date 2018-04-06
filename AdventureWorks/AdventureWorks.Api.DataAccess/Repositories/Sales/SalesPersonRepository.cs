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
	public class SalesPersonRepository: AbstractSalesPersonRepository, ISalesPersonRepository
	{
		public SalesPersonRepository(ILogger<SalesPersonRepository> logger,
		                             ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFSalesPerson> SearchLinqEF(Expression<Func<EFSalesPerson, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesPerson>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFSalesPerson>();
			}
			else
			{
				return this._context.Set<EFSalesPerson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesPerson>();
			}
		}

		protected override List<EFSalesPerson> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesPerson>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFSalesPerson>();
			}
			else
			{
				return this._context.Set<EFSalesPerson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesPerson>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>fa0bdbe9b78aba7f40e4c4c7ad9adf04</Hash>
</Codenesium>*/