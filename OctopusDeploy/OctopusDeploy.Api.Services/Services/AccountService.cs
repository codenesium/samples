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
	public partial class AccountService : AbstractAccountService, IAccountService
	{
		public AccountService(
			ILogger<IAccountRepository> logger,
			IAccountRepository accountRepository,
			IApiAccountRequestModelValidator accountModelValidator,
			IBOLAccountMapper bolaccountMapper,
			IDALAccountMapper dalaccountMapper
			)
			: base(logger,
			       accountRepository,
			       accountModelValidator,
			       bolaccountMapper,
			       dalaccountMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>82c7781e1122ab717018387a8e49c9a3</Hash>
</Codenesium>*/