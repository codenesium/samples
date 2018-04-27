using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public class SaleRepository: AbstractSaleRepository, ISaleRepository
	{
		public SaleRepository(
			IObjectMapper mapper,
			ILogger<SaleRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFSale> SearchLinqEF(Expression<Func<EFSale, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFSale>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFSale>();
			}
			else
			{
				return this.Context.Set<EFSale>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSale>();
			}
		}

		protected override List<EFSale> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFSale>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFSale>();
			}
			else
			{
				return this.Context.Set<EFSale>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSale>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>ecc502f6324069e9f82ef6ca20d515e7</Hash>
</Codenesium>*/