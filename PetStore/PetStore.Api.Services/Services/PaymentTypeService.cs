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
			IDALPaymentTypeMapper dalPaymentTypeMapper)
			: base(logger,
			       mediator,
			       paymentTypeRepository,
			       paymentTypeModelValidator,
			       dalPaymentTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e6043a85598a40978e7e5e22c5f4e4d1</Hash>
</Codenesium>*/