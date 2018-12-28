using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class DocumentService : AbstractDocumentService, IDocumentService
	{
		public DocumentService(
			ILogger<IDocumentRepository> logger,
			IMediator mediator,
			IDocumentRepository documentRepository,
			IApiDocumentServerRequestModelValidator documentModelValidator,
			IBOLDocumentMapper bolDocumentMapper,
			IDALDocumentMapper dalDocumentMapper)
			: base(logger,
			       mediator,
			       documentRepository,
			       documentModelValidator,
			       bolDocumentMapper,
			       dalDocumentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>34268b1f6cd060bbd48a4f71c3b88e8f</Hash>
</Codenesium>*/