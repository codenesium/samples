using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.DataAccess
{
	public partial class EfmigrationshistoryRepository : AbstractEfmigrationshistoryRepository, IEfmigrationshistoryRepository
	{
		public EfmigrationshistoryRepository(
			ILogger<EfmigrationshistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bb70e521b8a7ace6a152732611aaa885</Hash>
</Codenesium>*/