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
	public partial class UsersService : AbstractUsersService, IUsersService
	{
		public UsersService(
			ILogger<IUsersRepository> logger,
			IUsersRepository usersRepository,
			IApiUsersRequestModelValidator usersModelValidator,
			IBOLUsersMapper bolusersMapper,
			IDALUsersMapper dalusersMapper
			)
			: base(logger,
			       usersRepository,
			       usersModelValidator,
			       bolusersMapper,
			       dalusersMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0bd1851be6a0caaee1ca5fbaae0bc27e</Hash>
</Codenesium>*/