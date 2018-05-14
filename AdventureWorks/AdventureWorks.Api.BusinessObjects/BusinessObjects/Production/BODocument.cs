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
			IApiDocumentModelValidator documentModelValidator)
			: base(logger, documentRepository, documentModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>cde64f276cad14c402075527e09f08b1</Hash>
</Codenesium>*/