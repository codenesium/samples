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
	public partial class ProvinceRepository : AbstractProvinceRepository, IProvinceRepository
	{
		public ProvinceRepository(
			ILogger<ProvinceRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b5c76f3a50cbbba0b48e85af214cd077</Hash>
</Codenesium>*/