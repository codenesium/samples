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
			IDALLinkTypeMapper dalLinkTypeMapper,
			IDALPostLinkMapper dalPostLinkMapper)
			: base(logger,
			       mediator,
			       linkTypeRepository,
			       linkTypeModelValidator,
			       dalLinkTypeMapper,
			       dalPostLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7fa2ed1a590c932c6bb5343521b65c96</Hash>
</Codenesium>*/