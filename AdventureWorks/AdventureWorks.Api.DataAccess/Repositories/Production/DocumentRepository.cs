using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class DocumentRepository : AbstractDocumentRepository, IDocumentRepository
	{
		public DocumentRepository(
			ILogger<DocumentRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6f9026db4c8b89f1650d6859108796a3</Hash>
</Codenesium>*/