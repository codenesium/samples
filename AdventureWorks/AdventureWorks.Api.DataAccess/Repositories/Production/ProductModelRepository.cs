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
	public class ProductModelRepository: AbstractProductModelRepository, IProductModelRepository
	{
		public ProductModelRepository(ILogger<ProductModelRepository> logger,
		                              ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFProductModel> SearchLinqEF(Expression<Func<EFProductModel, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductModel>().Where(predicate).AsQueryable().OrderBy("ProductModelID ASC").Skip(skip).Take(take).ToList<EFProductModel>();
			}
			else
			{
				return this.context.Set<EFProductModel>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductModel>();
			}
		}

		protected override List<EFProductModel> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductModel>().Where(predicate).AsQueryable().OrderBy("ProductModelID ASC").Skip(skip).Take(take).ToList<EFProductModel>();
			}
			else
			{
				return this.context.Set<EFProductModel>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductModel>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>dd7f97e24e02098272175a159c999073</Hash>
</Codenesium>*/