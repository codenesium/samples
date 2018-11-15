using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class DocumentService : AbstractDocumentService, IDocumentService
	{
		public DocumentService(
			ILogger<IDocumentRepository> logger,
			IDocumentRepository documentRepository,
			IApiDocumentServerRequestModelValidator documentModelValidator,
			IBOLDocumentMapper bolDocumentMapper,
			IDALDocumentMapper dalDocumentMapper)
			: base(logger,
			       documentRepository,
			       documentModelValidator,
			       bolDocumentMapper,
			       dalDocumentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>af3cf8916540dd00e5dfd69e8ce80a8d</Hash>
</Codenesium>*/