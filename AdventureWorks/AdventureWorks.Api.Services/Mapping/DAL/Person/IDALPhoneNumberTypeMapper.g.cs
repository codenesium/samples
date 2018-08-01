using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALPhoneNumberTypeMapper
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
    <Hash>7dcb5b7fe98e4ed58f08622aa80345dd</Hash>
</Codenesium>*/