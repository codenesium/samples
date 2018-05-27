using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public class AdminRepository: AbstractAdminRepository, IAdminRepository
	{
		public AdminRepository(
			IDALAdminMapper mapper,
			ILogger<AdminRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>2d84cdba2382ef33c3d753540a488310</Hash>
</Codenesium>*/