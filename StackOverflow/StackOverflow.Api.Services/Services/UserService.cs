using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial class UserService : AbstractUserService, IUserService
	{
		public UserService(
			ILogger<IUserRepository> logger,
			IUserRepository userRepository,
			IApiUserRequestModelValidator userModelValidator,
			IBOLUserMapper boluserMapper,
			IDALUserMapper daluserMapper)
			: base(logger,
			       userRepository,
			       userModelValidator,
			       boluserMapper,
			       daluserMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>856c7a55e14a5292f1781824e90c172d</Hash>
</Codenesium>*/