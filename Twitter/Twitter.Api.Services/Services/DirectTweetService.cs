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
			IDALDirectTweetMapper dalDirectTweetMapper)
			: base(logger,
			       mediator,
			       directTweetRepository,
			       directTweetModelValidator,
			       dalDirectTweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>afb266e9731cc719d9a177c4f2eb83e2</Hash>
</Codenesium>*/