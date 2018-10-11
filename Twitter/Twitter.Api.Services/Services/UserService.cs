using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class UserService : AbstractUserService, IUserService
	{
		public UserService(
			ILogger<IUserRepository> logger,
			IUserRepository userRepository,
			IApiUserRequestModelValidator userModelValidator,
			IBOLUserMapper boluserMapper,
			IDALUserMapper daluserMapper,
			IBOLDirectTweetMapper bolDirectTweetMapper,
			IDALDirectTweetMapper dalDirectTweetMapper,
			IBOLFollowerMapper bolFollowerMapper,
			IDALFollowerMapper dalFollowerMapper,
			IBOLMessageMapper bolMessageMapper,
			IDALMessageMapper dalMessageMapper,
			IBOLMessengerMapper bolMessengerMapper,
			IDALMessengerMapper dalMessengerMapper,
			IBOLQuoteTweetMapper bolQuoteTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper,
			IBOLReplyMapper bolReplyMapper,
			IDALReplyMapper dalReplyMapper,
			IBOLRetweetMapper bolRetweetMapper,
			IDALRetweetMapper dalRetweetMapper,
			IBOLTweetMapper bolTweetMapper,
			IDALTweetMapper dalTweetMapper)
			: base(logger,
			       userRepository,
			       userModelValidator,
			       boluserMapper,
			       daluserMapper,
			       bolDirectTweetMapper,
			       dalDirectTweetMapper,
			       bolFollowerMapper,
			       dalFollowerMapper,
			       bolMessageMapper,
			       dalMessageMapper,
			       bolMessengerMapper,
			       dalMessengerMapper,
			       bolQuoteTweetMapper,
			       dalQuoteTweetMapper,
			       bolReplyMapper,
			       dalReplyMapper,
			       bolRetweetMapper,
			       dalRetweetMapper,
			       bolTweetMapper,
			       dalTweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5e3b33e4b8d62db3e806d7371af0136e</Hash>
</Codenesium>*/