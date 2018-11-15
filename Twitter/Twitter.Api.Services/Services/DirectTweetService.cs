using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class DirectTweetService : AbstractDirectTweetService, IDirectTweetService
	{
		public DirectTweetService(
			ILogger<IDirectTweetRepository> logger,
			IDirectTweetRepository directTweetRepository,
			IApiDirectTweetServerRequestModelValidator directTweetModelValidator,
			IBOLDirectTweetMapper bolDirectTweetMapper,
			IDALDirectTweetMapper dalDirectTweetMapper)
			: base(logger,
			       directTweetRepository,
			       directTweetModelValidator,
			       bolDirectTweetMapper,
			       dalDirectTweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1868dbc725e73299ac2d5fe14aa25e43</Hash>
</Codenesium>*/