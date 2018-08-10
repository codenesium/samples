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
    <Hash>d38e3d8c406e1c048494cf6c3214b334</Hash>
</Codenesium>*/