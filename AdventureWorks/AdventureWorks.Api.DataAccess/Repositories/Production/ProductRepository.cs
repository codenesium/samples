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
	public class ProductRepository: AbstractProductRepository, IProductRepository
	{
		public ProductRepository(ILogger<ProductRepository> logger,
		                         ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFProduct> SearchLinqEF(Expression<Func<EFProduct, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProduct>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProduct>();
			}
			else
			{
				return this.context.Set<EFProduct>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProduct>();
			}
		}

		protected override List<EFProduct> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProduct>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProduct>();
			}
			else
			{
				return this.context.Set<EFProduct>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProduct>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>6cbc847a1c63e12a2a6fc8ab28b28031</Hash>
</Codenesium>*/