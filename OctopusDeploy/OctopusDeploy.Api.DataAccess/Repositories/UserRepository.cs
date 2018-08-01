using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class UserRepository : AbstractUserRepository, IUserRepository
	{
		public UserRepository(
			ILogger<UserRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>97b628f5f1cb5fa308e6628fe162a955</Hash>
</Codenesium>*/