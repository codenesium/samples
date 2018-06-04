using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ProductDocumentRepository: AbstractProductDocumentRepository, IProductDocumentRepository
	{
		public ProductDocumentRepository(
			ILogger<ProductDocumentRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>7c9fabd16ffd57561e228489587d9c57</Hash>
</Codenesium>*/