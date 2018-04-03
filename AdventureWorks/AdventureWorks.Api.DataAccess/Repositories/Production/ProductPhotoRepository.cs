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
	public class ProductPhotoRepository: AbstractProductPhotoRepository, IProductPhotoRepository
	{
		public ProductPhotoRepository(ILogger<ProductPhotoRepository> logger,
		                              ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFProductPhoto> SearchLinqEF(Expression<Func<EFProductPhoto, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductPhoto>().Where(predicate).AsQueryable().OrderBy("productPhotoID ASC").Skip(skip).Take(take).ToList<EFProductPhoto>();
			}
			else
			{
				return this._context.Set<EFProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductPhoto>();
			}
		}

		protected override List<EFProductPhoto> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductPhoto>().Where(predicate).AsQueryable().OrderBy("productPhotoID ASC").Skip(skip).Take(take).ToList<EFProductPhoto>();
			}
			else
			{
				return this._context.Set<EFProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductPhoto>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>07bc265c690d64649ae0986208ba8714</Hash>
</Codenesium>*/