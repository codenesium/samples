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
		public ProductDocumentRepository(ILogger<ProductDocumentRepository> logger,
		                                 ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFProductDocument> SearchLinqEF(Expression<Func<EFProductDocument, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductDocument>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProductDocument>();
			}
			else
			{
				return this._context.Set<EFProductDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductDocument>();
			}
		}

		protected override List<EFProductDocument> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductDocument>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProductDocument>();
			}
			else
			{
				return this._context.Set<EFProductDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductDocument>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>90a3ef78a301c518d4e3a11920d59301</Hash>
</Codenesium>*/