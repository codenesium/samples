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
    <Hash>0a94a047e0c34f69f27d4fd713dde2bc</Hash>
</Codenesium>*/