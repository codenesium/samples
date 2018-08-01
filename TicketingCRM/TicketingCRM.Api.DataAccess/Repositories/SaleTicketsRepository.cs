using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>c3e98d44d789f98f8bd70ec6fa66dd21</Hash>
</Codenesium>*/