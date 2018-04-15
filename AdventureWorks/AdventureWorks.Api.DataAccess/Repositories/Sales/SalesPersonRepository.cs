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
		public SalesPersonRepository(
			IObjectMapper mapper,
			ILogger<SalesPersonRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFSalesPerson> SearchLinqEF(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSalesPerson>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFSalesPerson>();
			}
			else
			{
				return this.context.Set<EFSalesPerson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesPerson>();
			}
		}

		protected override List<EFSalesPerson> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSalesPerson>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFSalesPerson>();
			}
			else
			{
				return this.context.Set<EFSalesPerson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesPerson>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>fdcc5c78acdb920f271d0cc9a5d4f45c</Hash>
</Codenesium>*/