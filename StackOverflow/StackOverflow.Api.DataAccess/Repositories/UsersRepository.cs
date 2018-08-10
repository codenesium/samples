using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>a2d29d81ffa13888761277ef31faffd9</Hash>
</Codenesium>*/