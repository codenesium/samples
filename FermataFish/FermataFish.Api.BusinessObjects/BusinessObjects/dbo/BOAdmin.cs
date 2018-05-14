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
			IApiAdminModelValidator adminModelValidator)
			: base(logger, adminRepository, adminModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>92f284022a657c20f3bf235714efa045</Hash>
</Codenesium>*/