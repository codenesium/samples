using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>8aec27fec1b5ad46a757a26ea4a7226e</Hash>
</Codenesium>*/