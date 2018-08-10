using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial class UserService : AbstractUserService, IUserService
	{
		public UserService(
			ILogger<IUserRepository> logger,
			IUserRepository userRepository,
			IApiUserRequestModelValidator userModelValidator,
			IBOLUserMapper boluserMapper,
			IDALUserMapper daluserMapper
			)
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
    <Hash>a47ed319c39a1859d68c4c33ccaa3fcb</Hash>
</Codenesium>*/