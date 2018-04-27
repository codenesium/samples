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
			IPaymentTypeModelValidator paymentTypeModelValidator)
			: base(logger, paymentTypeRepository, paymentTypeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>2fadefd25ba7ddffbcd7dcbd188fe608</Hash>
</Codenesium>*/