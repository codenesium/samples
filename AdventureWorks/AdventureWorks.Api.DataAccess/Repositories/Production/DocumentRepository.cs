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
    <Hash>9dcaf5568fafe02ef043268bd8bd53b6</Hash>
</Codenesium>*/