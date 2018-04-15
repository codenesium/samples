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
	public class ProductDocumentRepository: AbstractProductDocumentRepository, IProductDocumentRepository
	{
		public ProductDocumentRepository(
			IObjectMapper mapper,
			ILogger<ProductDocumentRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFProductDocument> SearchLinqEF(Expression<Func<EFProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductDocument>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProductDocument>();
			}
			else
			{
				return this.context.Set<EFProductDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductDocument>();
			}
		}

		protected override List<EFProductDocument> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductDocument>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProductDocument>();
			}
			else
			{
				return this.context.Set<EFProductDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductDocument>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>156d3f98da0eab8b2282cbe5f0adebc0</Hash>
</Codenesium>*/