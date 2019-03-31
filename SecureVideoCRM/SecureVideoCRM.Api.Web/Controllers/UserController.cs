using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Web
{
	[Route("api/users")]
	[ApiController]
	[ApiVersion("1.0")]

	public class UserController : AbstractUserController
	{
		public UserController(
			ApiSettings settings,
			ILogger<UserController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUserService userService,
			IApiUserServerModelMapper userModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       userService,
			       userModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>385f6002cd6af9aaf88bc73b9fcfc713</Hash>
</Codenesium>*/