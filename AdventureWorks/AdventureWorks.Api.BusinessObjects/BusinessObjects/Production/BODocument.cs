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
	public class BODocument: AbstractBODocument, IBODocument
	{
		public BODocument(
			ILogger<DocumentRepository> logger,
			IDocumentRepository documentRepository,
			IApiDocumentRequestModelValidator documentModelValidator,
			IBOLDocumentMapper documentMapper)
			: base(logger, documentRepository, documentModelValidator, documentMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>bca3a53ddfe4d945c23816e96df2ddf6</Hash>
</Codenesium>*/