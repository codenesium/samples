using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class UsersRepository : AbstractUsersRepository, IUsersRepository
	{
		public UsersRepository(
			ILogger<UsersRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4bf591fe31c3137e4f8661d7d5190853</Hash>
</Codenesium>*/