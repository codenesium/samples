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
		public DocumentRepository(ILogger<DocumentRepository> logger,
		                          ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFDocument> SearchLinqEF(Expression<Func<EFDocument, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFDocument>().Where(predicate).AsQueryable().OrderBy("DocumentNode ASC").Skip(skip).Take(take).ToList<EFDocument>();
			}
			else
			{
				return this.context.Set<EFDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDocument>();
			}
		}

		protected override List<EFDocument> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
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
    <Hash>28cb72a80cc85d30f7b6720f1474e4d4</Hash>
</Codenesium>*/