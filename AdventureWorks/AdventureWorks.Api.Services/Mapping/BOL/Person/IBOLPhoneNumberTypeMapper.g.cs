using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLPhoneNumberTypeMapper
	{
		BOPhoneNumberType MapModelToBO(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeServerRequestModel model);

		ApiPhoneNumberTypeServerResponseModel MapBOToModel(
			BOPhoneNumberType boPhoneNumberType);

		List<ApiPhoneNumberTypeServerResponseModel> MapBOToModel(
			List<BOPhoneNumberType> items);
	}
}

/*<Codenesium>
    <Hash>0f9ec026ec062d01a0bccce694b71961</Hash>
</Codenesium>*/