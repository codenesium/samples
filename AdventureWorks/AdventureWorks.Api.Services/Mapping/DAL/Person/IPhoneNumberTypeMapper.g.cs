using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPhoneNumberTypeMapper
	{
		PhoneNumberType MapModelToEntity(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeServerRequestModel model);

		ApiPhoneNumberTypeServerResponseModel MapEntityToModel(
			PhoneNumberType item);

		List<ApiPhoneNumberTypeServerResponseModel> MapEntityToModel(
			List<PhoneNumberType> items);
	}
}

/*<Codenesium>
    <Hash>fbd7561f959dbc3c16b9bd5b256a7828</Hash>
</Codenesium>*/