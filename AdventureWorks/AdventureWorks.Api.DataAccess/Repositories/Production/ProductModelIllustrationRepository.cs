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
				return this._context.Set<EFProductModelIllustration>().Where(predicate).AsQueryable().OrderBy("productModelID ASC").Skip(skip).Take(take).ToList<EFProductModelIllustration>();
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
				return this._context.Set<EFProductModelIllustration>().Where(predicate).AsQueryable().OrderBy("productModelID ASC").Skip(skip).Take(take).ToList<EFProductModelIllustration>();
			}
			else
			{
				return this._context.Set<EFProductModelIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductModelIllustration>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>6d16c5cc049e7606eb324637b9fbdb91</Hash>
</Codenesium>*/