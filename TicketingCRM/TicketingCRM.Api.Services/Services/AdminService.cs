using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class AdminService : AbstractAdminService, IAdminService
	{
		public AdminService(
			ILogger<IAdminRepository> logger,
			IAdminRepository adminRepository,
			IApiAdminRequestModelValidator adminModelValidator,
			IBOLAdminMapper boladminMapper,
			IDALAdminMapper daladminMapper,
			IBOLVenueMapper bolVenueMapper,
			IDALVenueMapper dalVenueMapper
			)
			: base(logger,
			       adminRepository,
			       adminModelValidator,
			       boladminMapper,
			       daladminMapper,
			       bolVenueMapper,
			       dalVenueMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9bafd1208fa55f48e79c0829f055c1ee</Hash>
</Codenesium>*/