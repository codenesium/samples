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
	public class ProductProductPhotoRepository: AbstractProductProductPhotoRepository, IProductProductPhotoRepository
	{
		public ProductProductPhotoRepository(ILogger<ProductProductPhotoRepository> logger,
		                                     ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFProductProductPhoto> SearchLinqEF(Expression<Func<EFProductProductPhoto, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductProductPhoto>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProductProductPhoto>();
			}
			else
			{
				return this._context.Set<EFProductProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductProductPhoto>();
			}
		}

		protected override List<EFProductProductPhoto> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductProductPhoto>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProductProductPhoto>();
			}
			else
			{
				return this._context.Set<EFProductProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductProductPhoto>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>ca33d5bb2f37f332bcaed59f26f50035</Hash>
</Codenesium>*/