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
			IDALLinkTypeMapper dalLinkTypeMapper)
			: base(logger,
			       mediator,
			       linkTypeRepository,
			       linkTypeModelValidator,
			       dalLinkTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4faba38bf1aa536a2f6080a6e158d065</Hash>
</Codenesium>*/