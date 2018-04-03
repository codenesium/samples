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
				return this._context.Set<EFProductDocument>().Where(predicate).AsQueryable().OrderBy("productID ASC").Skip(skip).Take(take).ToList<EFProductDocument>();
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
				return this._context.Set<EFProductDocument>().Where(predicate).AsQueryable().OrderBy("productID ASC").Skip(skip).Take(take).ToList<EFProductDocument>();
			}
			else
			{
				return this._context.Set<EFProductDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductDocument>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>f5f07c1e7df21c711b0599715b70b7cb</Hash>
</Codenesium>*/