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
			IApiPaymentTypeModelValidator paymentTypeModelValidator)
			: base(logger, paymentTypeRepository, paymentTypeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>44e49d56bb19db27c534fd37389908ed</Hash>
</Codenesium>*/