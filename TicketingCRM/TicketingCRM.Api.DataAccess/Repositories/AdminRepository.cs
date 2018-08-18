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
    <Hash>da41b0f45e67cc66c425f6089c399c05</Hash>
</Codenesium>*/