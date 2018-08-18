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
    <Hash>64c3f451275694eb6c56ec2073c9aeb7</Hash>
</Codenesium>*/