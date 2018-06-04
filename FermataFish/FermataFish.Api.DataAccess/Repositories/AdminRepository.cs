using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class AdminRepository: AbstractAdminRepository, IAdminRepository
	{
		public AdminRepository(
			ILogger<AdminRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>48fabe8a60ed0350e70d635f526d3b40</Hash>
</Codenesium>*/