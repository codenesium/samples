using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public class PaymentTypeService: AbstractPaymentTypeService, IPaymentTypeService
	{
		public PaymentTypeService(
			ILogger<PaymentTypeRepository> logger,
			IPaymentTypeRepository paymentTypeRepository,
			IApiPaymentTypeRequestModelValidator paymentTypeModelValidator,
			IBOLPaymentTypeMapper BOLpaymentTypeMapper,
			IDALPaymentTypeMapper DALpaymentTypeMapper)
			: base(logger, paymentTypeRepository,
			       paymentTypeModelValidator,
			       BOLpaymentTypeMapper,
			       DALpaymentTypeMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>055829574ab053f87acc2c8a38a3736c</Hash>
</Codenesium>*/