using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class BOAdmin: AbstractBOAdmin, IBOAdmin
	{
		public BOAdmin(
			ILogger<AdminRepository> logger,
			IAdminRepository adminRepository,
			IApiAdminRequestModelValidator adminModelValidator,
			IBOLAdminMapper adminMapper)
			: base(logger, adminRepository, adminModelValidator, adminMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>63e50df2d79c8324785b50e3bcbf230f</Hash>
</Codenesium>*/