using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public partial class PaymentTypeService : AbstractPaymentTypeService, IPaymentTypeService
	{
		public PaymentTypeService(
			ILogger<IPaymentTypeRepository> logger,
			IPaymentTypeRepository paymentTypeRepository,
			IApiPaymentTypeServerRequestModelValidator paymentTypeModelValidator,
			IBOLPaymentTypeMapper bolPaymentTypeMapper,
			IDALPaymentTypeMapper dalPaymentTypeMapper,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper)
			: base(logger,
			       paymentTypeRepository,
			       paymentTypeModelValidator,
			       bolPaymentTypeMapper,
			       dalPaymentTypeMapper,
			       bolSaleMapper,
			       dalSaleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>87a14019e19c10b3f09c1d3057fe166c</Hash>
</Codenesium>*/