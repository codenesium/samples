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
	public class DocumentRepository: AbstractDocumentRepository, IDocumentRepository
	{
		public DocumentRepository(
			IDALDocumentMapper mapper,
			ILogger<DocumentRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>3c7c1748ccfcb38eda7e3e7244ca31ad</Hash>
</Codenesium>*/