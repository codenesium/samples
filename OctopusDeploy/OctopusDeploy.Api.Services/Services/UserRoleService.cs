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
	public partial class UserRoleService : AbstractUserRoleService, IUserRoleService
	{
		public UserRoleService(
			ILogger<IUserRoleRepository> logger,
			IUserRoleRepository userRoleRepository,
			IApiUserRoleRequestModelValidator userRoleModelValidator,
			IBOLUserRoleMapper boluserRoleMapper,
			IDALUserRoleMapper daluserRoleMapper
			)
			: base(logger,
			       userRoleRepository,
			       userRoleModelValidator,
			       boluserRoleMapper,
			       daluserRoleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2dd2373e19c8852a0a240135ebd97efc</Hash>
</Codenesium>*/