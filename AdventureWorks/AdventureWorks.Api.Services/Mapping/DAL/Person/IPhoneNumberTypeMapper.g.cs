using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPhoneNumberTypeMapper
	{
		PhoneNumberType MapModelToBO(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeServerRequestModel model);

		ApiPhoneNumberTypeServerResponseModel MapBOToModel(
			PhoneNumberType item);

		List<ApiPhoneNumberTypeServerResponseModel> MapBOToModel(
			List<PhoneNumberType> items);
	}
}

/*<Codenesium>
    <Hash>d0407da760b67391466e3cf4bc8e3e46</Hash>
</Codenesium>*/