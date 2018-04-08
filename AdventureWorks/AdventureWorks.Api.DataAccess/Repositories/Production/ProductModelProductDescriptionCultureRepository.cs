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
	public class ProductModelProductDescriptionCultureRepository: AbstractProductModelProductDescriptionCultureRepository, IProductModelProductDescriptionCultureRepository
	{
		public ProductModelProductDescriptionCultureRepository(ILogger<ProductModelProductDescriptionCultureRepository> logger,
		                                                       ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFProductModelProductDescriptionCulture> SearchLinqEF(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy("ProductModelID ASC").Skip(skip).Take(take).ToList<EFProductModelProductDescriptionCulture>();
			}
			else
			{
				return this.context.Set<EFProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductModelProductDescriptionCulture>();
			}
		}

		protected override List<EFProductModelProductDescriptionCulture> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy("ProductModelID ASC").Skip(skip).Take(take).ToList<EFProductModelProductDescriptionCulture>();
			}
			else
			{
				return this.context.Set<EFProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductModelProductDescriptionCulture>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>06dac26b7b49979d0382683b12b26858</Hash>
</Codenesium>*/