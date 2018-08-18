using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
	public partial class PaymentTypeRepository : AbstractPaymentTypeRepository, IPaymentTypeRepository
	{
		public PaymentTypeRepository(
			ILogger<PaymentTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3b27cfa5afcf5bbd814512abe0872280</Hash>
</Codenesium>*/