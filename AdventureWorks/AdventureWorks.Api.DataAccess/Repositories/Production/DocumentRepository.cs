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
		                          ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFDocument> SearchLinqEF(Expression<Func<EFDocument, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFDocument>().Where(predicate).AsQueryable().OrderBy("documentNode ASC").Skip(skip).Take(take).ToList<EFDocument>();
			}
			else
			{
				return this._context.Set<EFDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDocument>();
			}
		}

		protected override List<EFDocument> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFDocument>().Where(predicate).AsQueryable().OrderBy("documentNode ASC").Skip(skip).Take(take).ToList<EFDocument>();
			}
			else
			{
				return this._context.Set<EFDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDocument>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>3f0aab1cf9bc299d94a23de30bb1c44e</Hash>
</Codenesium>*/