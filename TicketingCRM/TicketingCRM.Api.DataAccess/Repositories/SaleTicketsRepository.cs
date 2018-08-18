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
	public partial class SaleTicketsRepository : AbstractSaleTicketsRepository, ISaleTicketsRepository
	{
		public SaleTicketsRepository(
			ILogger<SaleTicketsRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8921352b811c642de01335936d6b10bc</Hash>
</Codenesium>*/