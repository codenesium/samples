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
			IDALPhoneNumberTypeMapper dalPhoneNumberTypeMapper)
			: base(logger,
			       mediator,
			       phoneNumberTypeRepository,
			       phoneNumberTypeModelValidator,
			       dalPhoneNumberTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f1fb6338a97c4192c14fcc169728f7c0</Hash>
</Codenesium>*/