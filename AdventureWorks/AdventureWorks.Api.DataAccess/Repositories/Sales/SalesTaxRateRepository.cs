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
	public class SalesTaxRateRepository: AbstractSalesTaxRateRepository, ISalesTaxRateRepository
	{
		public SalesTaxRateRepository(
			IObjectMapper mapper,
			ILogger<SalesTaxRateRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFSalesTaxRate> SearchLinqEF(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSalesTaxRate>().Where(predicate).AsQueryable().OrderBy("SalesTaxRateID ASC").Skip(skip).Take(take).ToList<EFSalesTaxRate>();
			}
			else
			{
				return this.context.Set<EFSalesTaxRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesTaxRate>();
			}
		}

		protected override List<EFSalesTaxRate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSalesTaxRate>().Where(predicate).AsQueryable().OrderBy("SalesTaxRateID ASC").Skip(skip).Take(take).ToList<EFSalesTaxRate>();
			}
			else
			{
				return this.context.Set<EFSalesTaxRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesTaxRate>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>c7bab22358701b92763af0c019374c13</Hash>
</Codenesium>*/