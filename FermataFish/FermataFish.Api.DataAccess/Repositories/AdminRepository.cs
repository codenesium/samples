using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
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
    <Hash>f9df8b8a2dcb787049433f933ede9fc3</Hash>
</Codenesium>*/