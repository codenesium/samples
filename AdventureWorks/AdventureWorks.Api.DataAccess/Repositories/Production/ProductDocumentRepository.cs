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
			IDALProductDocumentMapper mapper,
			ILogger<ProductDocumentRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>e9fcac3629d2f7bcf8a404c650cbfb75</Hash>
</Codenesium>*/