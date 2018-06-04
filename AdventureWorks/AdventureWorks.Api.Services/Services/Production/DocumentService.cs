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
	public class DocumentService: AbstractDocumentService, IDocumentService
	{
		public DocumentService(
			ILogger<DocumentRepository> logger,
			IDocumentRepository documentRepository,
			IApiDocumentRequestModelValidator documentModelValidator,
			IBOLDocumentMapper BOLdocumentMapper,
			IDALDocumentMapper DALdocumentMapper)
			: base(logger, documentRepository,
			       documentModelValidator,
			       BOLdocumentMapper,
			       DALdocumentMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>7204a72d0670aaa169d1e85640226c50</Hash>
</Codenesium>*/