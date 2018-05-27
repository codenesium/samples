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
			IApiProductDocumentRequestModelValidator productDocumentModelValidator,
			IBOLProductDocumentMapper productDocumentMapper)
			: base(logger, productDocumentRepository, productDocumentModelValidator, productDocumentMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>49754fd3edd894ab78bab163a473ff9e</Hash>
</Codenesium>*/