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
    <Hash>3df6cc8d7907d2c134e979d7b83e3c1f</Hash>
</Codenesium>*/