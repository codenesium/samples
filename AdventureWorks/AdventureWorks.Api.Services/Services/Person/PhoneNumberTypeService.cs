using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class PhoneNumberTypeService : AbstractPhoneNumberTypeService, IPhoneNumberTypeService
	{
		public PhoneNumberTypeService(
			ILogger<IPhoneNumberTypeRepository> logger,
			IMediator mediator,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IApiPhoneNumberTypeServerRequestModelValidator phoneNumberTypeModelValidator,
			IBOLPhoneNumberTypeMapper bolPhoneNumberTypeMapper,
			IDALPhoneNumberTypeMapper dalPhoneNumberTypeMapper)
			: base(logger,
			       mediator,
			       phoneNumberTypeRepository,
			       phoneNumberTypeModelValidator,
			       bolPhoneNumberTypeMapper,
			       dalPhoneNumberTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f76a68a11eb248e55de4b642d80ca172</Hash>
</Codenesium>*/