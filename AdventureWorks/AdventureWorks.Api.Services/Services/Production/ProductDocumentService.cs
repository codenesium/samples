using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ProductDocumentService: AbstractProductDocumentService, IProductDocumentService
	{
		public ProductDocumentService(
			ILogger<ProductDocumentRepository> logger,
			IProductDocumentRepository productDocumentRepository,
			IApiProductDocumentRequestModelValidator productDocumentModelValidator,
			IBOLProductDocumentMapper BOLproductDocumentMapper,
			IDALProductDocumentMapper DALproductDocumentMapper)
			: base(logger, productDocumentRepository,
			       productDocumentModelValidator,
			       BOLproductDocumentMapper,
			       DALproductDocumentMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>83eef3a1a56d6c20ee1666f8c953de27</Hash>
</Codenesium>*/