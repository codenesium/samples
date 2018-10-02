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
	public partial class SaleTicketRepository : AbstractSaleTicketRepository, ISaleTicketRepository
	{
		public SaleTicketRepository(
			ILogger<SaleTicketRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f6efe3ecf0295449ab2e0d39417569b4</Hash>
</Codenesium>*/