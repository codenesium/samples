using MediatR;
using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class DirectTweetService : AbstractDirectTweetService, IDirectTweetService
	{
		public DirectTweetService(
			ILogger<IDirectTweetRepository> logger,
			IMediator mediator,
			IDirectTweetRepository directTweetRepository,
			IApiDirectTweetServerRequestModelValidator directTweetModelValidator,
			IBOLDirectTweetMapper bolDirectTweetMapper,
			IDALDirectTweetMapper dalDirectTweetMapper)
			: base(logger,
			       mediator,
			       directTweetRepository,
			       directTweetModelValidator,
			       bolDirectTweetMapper,
			       dalDirectTweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9887bea8165d46d16667419c56bf5aaf</Hash>
</Codenesium>*/