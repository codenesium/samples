using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class LinkTypesService : AbstractLinkTypesService, ILinkTypesService
	{
		public LinkTypesService(
			ILogger<ILinkTypesRepository> logger,
			IMediator mediator,
			ILinkTypesRepository linkTypesRepository,
			IApiLinkTypesServerRequestModelValidator linkTypesModelValidator,
			IDALLinkTypesMapper dalLinkTypesMapper,
			IDALPostLinksMapper dalPostLinksMapper)
			: base(logger,
			       mediator,
			       linkTypesRepository,
			       linkTypesModelValidator,
			       dalLinkTypesMapper,
			       dalPostLinksMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6b757181cb46dd7ead860c548d356c56</Hash>
</Codenesium>*/