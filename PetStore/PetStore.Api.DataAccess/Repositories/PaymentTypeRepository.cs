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
    <Hash>0268910e4ffceb0b8dbf7271a8b5f642</Hash>
</Codenesium>*/