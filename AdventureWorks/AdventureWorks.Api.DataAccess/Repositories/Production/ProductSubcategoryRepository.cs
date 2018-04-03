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
	public class ProductSubcategoryRepository: AbstractProductSubcategoryRepository, IProductSubcategoryRepository
	{
		public ProductSubcategoryRepository(ILogger<ProductSubcategoryRepository> logger,
		                                    ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFProductSubcategory> SearchLinqEF(Expression<Func<EFProductSubcategory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy("productSubcategoryID ASC").Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
			else
			{
				return this._context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
		}

		protected override List<EFProductSubcategory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy("productSubcategoryID ASC").Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
			else
			{
				return this._context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>13406d49a496667cafc061628afdc168</Hash>
</Codenesium>*/