using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOProductDocument: AbstractBOProductDocument, IBOProductDocument
	{
		public BOProductDocument(
			ILogger<ProductDocumentRepository> logger,
			IProductDocumentRepository productDocumentRepository,
			IProductDocumentModelValidator productDocumentModelValidator)
			: base(logger, productDocumentRepository, productDocumentModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>fead7d30f5e70b457b29918ef3d509f4</Hash>
</Codenesium>*/