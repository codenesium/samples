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
	public partial class AccountRepository : AbstractAccountRepository, IAccountRepository
	{
		public AccountRepository(
			ILogger<AccountRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>aef1228e5d393ddf80900ef67f79ec2a</Hash>
</Codenesium>*/