using MediatR;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public partial class PaymentTypeService : AbstractPaymentTypeService, IPaymentTypeService
	{
		public PaymentTypeService(
			ILogger<IPaymentTypeRepository> logger,
			IMediator mediator,
			IPaymentTypeRepository paymentTypeRepository,
			IApiPaymentTypeServerRequestModelValidator paymentTypeModelValidator,
			IDALPaymentTypeMapper dalPaymentTypeMapper,
			IDALSaleMapper dalSaleMapper)
			: base(logger,
			       mediator,
			       paymentTypeRepository,
			       paymentTypeModelValidator,
			       dalPaymentTypeMapper,
			       dalSaleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f0e42d62ee35e29387d1de56da076118</Hash>
</Codenesium>*/