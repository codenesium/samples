using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class AdminService : AbstractAdminService, IAdminService
	{
		public AdminService(
			ILogger<IAdminRepository> logger,
			IAdminRepository adminRepository,
			IApiAdminRequestModelValidator adminModelValidator,
			IBOLAdminMapper boladminMapper,
			IDALAdminMapper daladminMapper)
			: base(logger,
			       adminRepository,
			       adminModelValidator,
			       boladminMapper,
			       daladminMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>00b239f23773fbaf53d99a781ba5bd84</Hash>
</Codenesium>*/