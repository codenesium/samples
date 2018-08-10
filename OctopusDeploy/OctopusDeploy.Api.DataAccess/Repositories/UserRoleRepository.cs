using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class UserRoleRepository : AbstractUserRoleRepository, IUserRoleRepository
	{
		public UserRoleRepository(
			ILogger<UserRoleRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ae0c5ddc17c25bec101361913fc7d543</Hash>
</Codenesium>*/