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
    <Hash>1a70daf6c2bd7de6af3280cf68e019ef</Hash>
</Codenesium>*/