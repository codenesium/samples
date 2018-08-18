using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPhoneNumberTypeMapper
	{
		PhoneNumberType MapBOToEF(
			BOPhoneNumberType bo);

		BOPhoneNumberType MapEFToBO(
			PhoneNumberType efPhoneNumberType);

		List<BOPhoneNumberType> MapEFToBO(
			List<PhoneNumberType> records);
	}
}

/*<Codenesium>
    <Hash>e7a4168f6bf48fb4070194ebda689436</Hash>
</Codenesium>*/