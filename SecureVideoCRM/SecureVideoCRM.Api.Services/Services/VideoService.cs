using MediatR;
using Microsoft.Extensions.Logging;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;

namespace SecureVideoCRMNS.Api.Services
{
	public partial class VideoService : AbstractVideoService, IVideoService
	{
		public VideoService(
			ILogger<IVideoRepository> logger,
			IMediator mediator,
			IVideoRepository videoRepository,
			IApiVideoServerRequestModelValidator videoModelValidator,
			IDALVideoMapper dalVideoMapper)
			: base(logger,
			       mediator,
			       videoRepository,
			       videoModelValidator,
			       dalVideoMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2195d80a058a0193dec1b16eb2be8a96</Hash>
</Codenesium>*/