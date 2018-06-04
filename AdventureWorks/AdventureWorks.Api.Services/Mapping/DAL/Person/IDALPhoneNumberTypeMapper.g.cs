using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>5c508f7e8c1b221e371a28fd33f130ca</Hash>
</Codenesium>*/