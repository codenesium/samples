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
			IDocumentModelValidator documentModelValidator)
			: base(logger, documentRepository, documentModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>9cbb6901921e9d9fd7144692e989c785</Hash>
</Codenesium>*/