using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class PhoneNumberTypeService : AbstractPhoneNumberTypeService, IPhoneNumberTypeService
	{
		public PhoneNumberTypeService(
			ILogger<IPhoneNumberTypeRepository> logger,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IApiPhoneNumberTypeServerRequestModelValidator phoneNumberTypeModelValidator,
			IBOLPhoneNumberTypeMapper bolPhoneNumberTypeMapper,
			IDALPhoneNumberTypeMapper dalPhoneNumberTypeMapper)
			: base(logger,
			       phoneNumberTypeRepository,
			       phoneNumberTypeModelValidator,
			       bolPhoneNumberTypeMapper,
			       dalPhoneNumberTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>25b97eb979a85f5e0342aaf218df0675</Hash>
</Codenesium>*/