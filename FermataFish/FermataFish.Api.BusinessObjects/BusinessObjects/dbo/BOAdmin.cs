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
			IAdminModelValidator adminModelValidator)
			: base(logger, adminRepository, adminModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>63f03a36d513abc691a4d6220e500f73</Hash>
</Codenesium>*/