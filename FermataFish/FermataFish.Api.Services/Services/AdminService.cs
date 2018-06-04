using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class AdminService: AbstractAdminService, IAdminService
	{
		public AdminService(
			ILogger<AdminRepository> logger,
			IAdminRepository adminRepository,
			IApiAdminRequestModelValidator adminModelValidator,
			IBOLAdminMapper BOLadminMapper,
			IDALAdminMapper DALadminMapper)
			: base(logger, adminRepository,
			       adminModelValidator,
			       BOLadminMapper,
			       DALadminMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>23c38b120d9676df53a8ca669038606b</Hash>
</Codenesium>*/