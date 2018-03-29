using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/passwords")]
	public class PasswordsController: AbstractPasswordsController
	{
		public PasswordsController(
			ILogger<PasswordsController> logger,
			ApplicationContext context,
			IPasswordRepository passwordRepository,
			IPasswordModelValidator passwordModelValidator
			) : base(logger,
			         context,
			         passwordRepository,
			         passwordModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e4db6025a2e01c14196d9040feb9372b</Hash>
</Codenesium>*/