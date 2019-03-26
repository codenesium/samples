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
			IDALDocumentMapper dalDocumentMapper)
			: base(logger,
			       mediator,
			       documentRepository,
			       documentModelValidator,
			       dalDocumentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>078f0d7d3b2c26883a91e22ed379c4b4</Hash>
</Codenesium>*/