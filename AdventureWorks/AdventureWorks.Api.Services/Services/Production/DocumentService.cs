using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class DocumentService : AbstractDocumentService, IDocumentService
	{
		public DocumentService(
			ILogger<IDocumentRepository> logger,
			IDocumentRepository documentRepository,
			IApiDocumentRequestModelValidator documentModelValidator,
			IBOLDocumentMapper boldocumentMapper,
			IDALDocumentMapper daldocumentMapper
			)
			: base(logger,
			       documentRepository,
			       documentModelValidator,
			       boldocumentMapper,
			       daldocumentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f08bfe8e1b589f0daa1d1da5978aba76</Hash>
</Codenesium>*/