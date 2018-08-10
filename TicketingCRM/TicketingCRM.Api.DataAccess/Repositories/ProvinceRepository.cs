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
    <Hash>176b0f29b82374cc57f342e028d558f6</Hash>
</Codenesium>*/