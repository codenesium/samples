using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Web
{
	[Route("api/users")]
	[ApiController]
	[ApiVersion("1.0")]

	public class UsersController : AbstractUsersController
	{
		public UsersController(
			ApiSettings settings,
			ILogger<UsersController> logger,
			ITransactionCoordinator transactionCoordinator,
			IUsersService usersService,
			IApiUsersServerModelMapper usersModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       usersService,
			       usersModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>80f600199c72ef792f1b099895ec2cff</Hash>
</Codenesium>*/