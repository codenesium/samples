using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>b6994e5dbc80d0218cd5027272a6f599</Hash>
</Codenesium>*/