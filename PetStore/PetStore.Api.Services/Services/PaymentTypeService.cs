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
			IDALSaleMapper dalSaleMapper
			)
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
    <Hash>2060c975472c83abaf969703c973f06a</Hash>
</Codenesium>*/