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
			IApiProductDocumentModelValidator productDocumentModelValidator)
			: base(logger, productDocumentRepository, productDocumentModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>c69ea825b44402994848b12c4e2a4146</Hash>
</Codenesium>*/