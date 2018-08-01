using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>906791876f61cabf980328ba0efe0214</Hash>
</Codenesium>*/