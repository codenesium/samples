using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class LinkTypeService : AbstractLinkTypeService, ILinkTypeService
	{
		public LinkTypeService(
			ILogger<ILinkTypeRepository> logger,
			IMediator mediator,
			ILinkTypeRepository linkTypeRepository,
			IApiLinkTypeServerRequestModelValidator linkTypeModelValidator,
			IBOLLinkTypeMapper bolLinkTypeMapper,
			IDALLinkTypeMapper dalLinkTypeMapper)
			: base(logger,
			       mediator,
			       linkTypeRepository,
			       linkTypeModelValidator,
			       bolLinkTypeMapper,
			       dalLinkTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>dbb29c44604544fd43cd8b6b4d0473fb</Hash>
</Codenesium>*/