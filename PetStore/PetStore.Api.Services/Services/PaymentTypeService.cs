using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial class PaymentTypeService : AbstractPaymentTypeService, IPaymentTypeService
	{
		public PaymentTypeService(
			ILogger<IPaymentTypeRepository> logger,
			IPaymentTypeRepository paymentTypeRepository,
			IApiPaymentTypeRequestModelValidator paymentTypeModelValidator,
			IBOLPaymentTypeMapper bolpaymentTypeMapper,
			IDALPaymentTypeMapper dalpaymentTypeMapper,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper)
			: base(logger,
			       paymentTypeRepository,
			       paymentTypeModelValidator,
			       bolpaymentTypeMapper,
			       dalpaymentTypeMapper,
			       bolSaleMapper,
			       dalSaleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>70ae55409b75b5b935c3fc9d47d0f6c1</Hash>
</Codenesium>*/