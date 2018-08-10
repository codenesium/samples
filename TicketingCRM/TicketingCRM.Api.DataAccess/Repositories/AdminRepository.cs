using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial class AdminRepository : AbstractAdminRepository, IAdminRepository
	{
		public AdminRepository(
			ILogger<AdminRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a1ec7b93b0b958b018577be1a0f78222</Hash>
</Codenesium>*/