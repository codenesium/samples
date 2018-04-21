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
		public ProductPhotoRepository(
			IObjectMapper mapper,
			ILogger<ProductPhotoRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFProductPhoto> SearchLinqEF(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFProductPhoto>().Where(predicate).AsQueryable().OrderBy("ProductPhotoID ASC").Skip(skip).Take(take).ToList<EFProductPhoto>();
			}
			else
			{
				return this.Context.Set<EFProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductPhoto>();
			}
		}

		protected override List<EFProductPhoto> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFProductPhoto>().Where(predicate).AsQueryable().OrderBy("ProductPhotoID ASC").Skip(skip).Take(take).ToList<EFProductPhoto>();
			}
			else
			{
				return this.Context.Set<EFProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductPhoto>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>63e6bf3c370752a6d0fa644a9a2af7c4</Hash>
</Codenesium>*/