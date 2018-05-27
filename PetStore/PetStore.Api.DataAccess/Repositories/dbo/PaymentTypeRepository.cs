using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public class PaymentTypeRepository: AbstractPaymentTypeRepository, IPaymentTypeRepository
	{
		public PaymentTypeRepository(
			IDALPaymentTypeMapper mapper,
			ILogger<PaymentTypeRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>b50ad93518e26a6717537cb00cb2b8ea</Hash>
</Codenesium>*/