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
	public class DocumentRepository: AbstractDocumentRepository, IDocumentRepository
	{
		public DocumentRepository(
			IObjectMapper mapper,
			ILogger<DocumentRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFDocument> SearchLinqEF(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFDocument>().Where(predicate).AsQueryable().OrderBy("DocumentNode ASC").Skip(skip).Take(take).ToList<EFDocument>();
			}
			else
			{
				return this.context.Set<EFDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDocument>();
			}
		}

		protected override List<EFDocument> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFDocument>().Where(predicate).AsQueryable().OrderBy("DocumentNode ASC").Skip(skip).Take(take).ToList<EFDocument>();
			}
			else
			{
				return this.context.Set<EFDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDocument>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>36c59c99f92b98758461220b2f33a297</Hash>
</Codenesium>*/