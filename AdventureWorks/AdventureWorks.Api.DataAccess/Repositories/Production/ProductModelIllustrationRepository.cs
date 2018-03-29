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
	public class ProductModelIllustrationRepository: AbstractProductModelIllustrationRepository, IProductModelIllustrationRepository
	{
		public ProductModelIllustrationRepository(ILogger<ProductModelIllustrationRepository> logger,
		                                          ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFProductModelIllustration> SearchLinqEF(Expression<Func<EFProductModelIllustration, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductModelIllustration>().Where(predicate).AsQueryable().OrderBy("ProductModelID ASC").Skip(skip).Take(take).ToList<EFProductModelIllustration>();
			}
			else
			{
				return this._context.Set<EFProductModelIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductModelIllustration>();
			}
		}

		protected override List<EFProductModelIllustration> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductModelIllustration>().Where(predicate).AsQueryable().OrderBy("ProductModelID ASC").Skip(skip).Take(take).ToList<EFProductModelIllustration>();
			}
			else
			{
				return this._context.Set<EFProductModelIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductModelIllustration>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>cb80b43a86b2a0da1e9bb5110a03eebb</Hash>
</Codenesium>*/