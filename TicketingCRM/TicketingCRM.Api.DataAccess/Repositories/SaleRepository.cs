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
	public partial class SaleRepository : AbstractSaleRepository, ISaleRepository
	{
		public SaleRepository(
			ILogger<SaleRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1845ea0ff26baafd87fa1ef38d61747c</Hash>
</Codenesium>*/