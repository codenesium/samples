using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public class BOPaymentType: AbstractBOPaymentType, IBOPaymentType
	{
		public BOPaymentType(
			ILogger<PaymentTypeRepository> logger,
			IPaymentTypeRepository paymentTypeRepository,
			IApiPaymentTypeRequestModelValidator paymentTypeModelValidator,
			IBOLPaymentTypeMapper paymentTypeMapper)
			: base(logger, paymentTypeRepository, paymentTypeModelValidator, paymentTypeMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>4815ca02df59554b7bb8baa527b027a3</Hash>
</Codenesium>*/